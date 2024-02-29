import Box from '@mui/joy/Box'
import Breadcrumbs from '@mui/joy/Breadcrumbs'
import Link from '@mui/joy/Link'
import Typography from '@mui/joy/Typography'

import ChevronRightRoundedIcon from '@mui/icons-material/ChevronRightRounded'
import HomeRoundedIcon from '@mui/icons-material/HomeRounded'

import MenuList from './components/MenuList'

const NavigationMenuPage = () => {
 return (
  <>
   <Box sx={{ display: 'flex', alignItems: 'center' }}>
    <Breadcrumbs
     size='sm'
     aria-label='breadcrumbs'
     separator={<ChevronRightRoundedIcon fontSize='small' />}
     sx={{ pl: 0 }}
    >
     <Link
      underline='none'
      color='neutral'
      href='#some-link'
      aria-label='Home'
     >
      <HomeRoundedIcon />
     </Link>
     <Typography
      color='primary'
      fontWeight={500}
      fontSize={12}
     >
      Menus
     </Typography>
    </Breadcrumbs>
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
    <MenuList />
   </Box>
  </>
 )
}

export default NavigationMenuPage
