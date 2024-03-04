import ChevronRightRounded from '@mui/icons-material/ChevronRightRounded'
import HomeRounded from '@mui/icons-material/HomeRounded'
import { Breadcrumbs, Link, Typography } from '@mui/joy'
import React from 'react'
import { useNavigate } from 'react-router-dom'

interface CustomBreadcrumsProps {
 data: any[]
}

const CustomBreadcrums = ({ data }: CustomBreadcrumsProps) => {
 const navigate = useNavigate()

 return (
  <Breadcrumbs
   size='sm'
   aria-label='breadcrumbs'
   separator={<ChevronRightRounded />}
   sx={{ pl: 0 }}
  >
   <Link
    color='neutral'
    underline='none'
    onClick={() => navigate('/')}
   >
    <HomeRounded />
   </Link>

   {data.map((x, i) => (
    <React.Fragment key={i}>
     {i !== data.length - 1 && (
      <Link
       underline='none'
       color='neutral'
       onClick={() => navigate(x.to)}
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
    </React.Fragment>
   ))}
  </Breadcrumbs>
 )
}

export default CustomBreadcrums
