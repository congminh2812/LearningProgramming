import { Box, Button } from '@mui/joy'
import Typography from '@mui/joy/Typography'
import NavigationMenuApi from 'api/navigationMenuApi'
import CustomBreadcrums from 'components/CustomBreadcrumbs'

export default function DashboardPage() {
 const breadcrumbs = [
  {
   name: 'Dashboard',
  },
 ]

 const handleClick = () => {
  NavigationMenuApi.getNavigationMenus()
   .then((res) => {})
   .catch((e) => console.log(e))
 }
 return (
  <>
   <Box sx={{ display: 'flex', alignItems: 'center' }}>
    <CustomBreadcrums data={breadcrumbs} />
   </Box>
   <Typography
    level='h2'
    component='h1'
   >
    Dashboard
   </Typography>
   <Button onClick={handleClick}>Click</Button>
  </>
 )
}
