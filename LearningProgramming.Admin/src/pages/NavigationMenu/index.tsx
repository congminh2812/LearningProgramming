import Box from '@mui/joy/Box'

import { CircularProgress } from '@mui/joy'
import { fetchNavigationMenus } from 'app/slices/navigationMenuSlice'
import { useAppDispatch, useAppSelector } from 'app/store'
import CustomBreadcrums from 'components/CustomBreadcrumbs'
import { useEffect } from 'react'
import MenuList from './components/MenuList'

const NavigationMenuPage = () => {
 const dispatch = useAppDispatch()
 const { menus, loading } = useAppSelector((state) => state.navigationMenu)

 const breadcrumbs = [
  {
   name: 'Menus',
  },
 ]

 useEffect(() => {
  dispatch(fetchNavigationMenus())
 }, [dispatch])

 if (loading)
  return (
   <Box
    width='100%'
    height='100%'
    display='flex'
    justifyContent='center'
    alignItems='center'
   >
    <CircularProgress />
   </Box>
  )

 return (
  <>
   <Box sx={{ display: 'flex', alignItems: 'center' }}>
    <CustomBreadcrums data={breadcrumbs} />
   </Box>
   <Box
    sx={{
     display: 'flex',
     mb: 1,
     gap: 1,
     flexDirection: { xs: 'column', sm: 'row' },
     alignItems: { xs: 'start', sm: 'center' },
     flexWrap: 'wrap',
     justifyContent: 'space-between',
    }}
   >
    <MenuList menus={menus} />
   </Box>
  </>
 )
}

export default NavigationMenuPage
