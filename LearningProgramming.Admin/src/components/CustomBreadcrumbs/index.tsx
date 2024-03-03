import { default as ChevronRightRoundedIcon, default as HomeRoundedIcon } from '@mui/icons-material/ChevronRightRounded'
import { Breadcrumbs, Typography } from '@mui/joy'
import { Link } from 'react-router-dom'

interface CustomBreadcrumsProps {
 data: any[]
}

const CustomBreadcrums = ({ data }: CustomBreadcrumsProps) => {
 return (
  <Breadcrumbs
   size='sm'
   aria-label='breadcrumbs'
   separator={<ChevronRightRoundedIcon />}
   sx={{ pl: 0 }}
  >
   <Link
    color='neutral'
    to='/'
   >
    <HomeRoundedIcon />
   </Link>

   {data.map((x, i) => (
    <>
     {i !== data.length - 1 && (
      <Link
       color='neutral'
       to={x.to}
      >
       {x.name}
      </Link>
     )}
     {i === data.length - 1 && (
      <Typography
       color='primary'
       fontWeight={500}
       fontSize={12}
      >
       {x.name}
      </Typography>
     )}
    </>
   ))}
  </Breadcrumbs>
 )
}

export default CustomBreadcrums
