import { Box, Breadcrumbs, Button, Link } from '@mui/joy'
import Typography from '@mui/joy/Typography'
import ChevronRightRoundedIcon from '@mui/icons-material/ChevronRightRounded'
import HomeRoundedIcon from '@mui/icons-material/HomeRounded'
import NavigationMenuApi from 'api/navigationMenuApi'

export default function DashboardPage() {
 const handleClick = () => {
  NavigationMenuApi.getNavigationMenus()
   .then((res) => {})
   .catch((e) => console.log(e))
 }

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
     <Link
      underline='hover'
      color='neutral'
      href='#some-link'
      fontSize={12}
      fontWeight={500}
     >
      Dashboard
     </Link>
    </Breadcrumbs>
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
