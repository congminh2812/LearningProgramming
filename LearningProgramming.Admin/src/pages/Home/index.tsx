import Box from '@mui/joy/Box'
import Breadcrumbs from '@mui/joy/Breadcrumbs'
import CssBaseline from '@mui/joy/CssBaseline'
import Link from '@mui/joy/Link'
import { CssVarsProvider } from '@mui/joy/styles'
import DashboardPage from 'pages/Dashboard'
import { Route, Routes } from 'react-router-dom'

import ChevronRightRoundedIcon from '@mui/icons-material/ChevronRightRounded'
import HomeRoundedIcon from '@mui/icons-material/HomeRounded'

import Header from 'components/Header'
import Sidebar from 'components/Sidebar'

import { useAuth } from 'components/AuthProvider'
import { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

const HomePage = () => {
 const navigate = useNavigate()
 const { isLoggedIn } = useAuth()

 useEffect(() => {
  if (!isLoggedIn) {
   navigate('/login')
  }
 }, [isLoggedIn, navigate])

 return (
  <CssVarsProvider disableTransitionOnChange>
   <CssBaseline />
   <Box sx={{ display: 'flex', minHeight: '100dvh' }}>
    <Header />
    <Sidebar />
    <Box
     component='main'
     className='MainContent'
     sx={{
      px: { xs: 2, md: 6 },
      pt: {
       xs: 'calc(12px + var(--Header-height))',
       sm: 'calc(12px + var(--Header-height))',
       md: 3,
      },
      pb: { xs: 2, sm: 2, md: 3 },
      flex: 1,
      display: 'flex',
      flexDirection: 'column',
      minWidth: 0,
      height: '100dvh',
      gap: 1,
     }}
    >
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
      <Routes>
       <Route
        path='/'
        element={<DashboardPage />}
       />
      </Routes>
     </Box>
    </Box>
   </Box>
  </CssVarsProvider>
 )
}

export default HomePage
