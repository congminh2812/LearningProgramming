import Box from '@mui/joy/Box'
import CssBaseline from '@mui/joy/CssBaseline'
import { CssVarsProvider } from '@mui/joy/styles'
import { Outlet, Route, Router, Routes } from 'react-router-dom'

import Header from 'components/Header'
import Sidebar from 'components/Sidebar'

import { useAuth } from 'components/AuthProvider'
import { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import DashboardPage from 'pages/Dashboard'
import UsersPage from 'pages/Users'
import NavigationMenuPage from 'pages/NavigationMenu'

const HomePage = () => {
 const navigate = useNavigate()
 const { isLoggedIn } = useAuth()

 useEffect(() => {
  if (!isLoggedIn) {
   navigate('/login')
  }
 }, [isLoggedIn, navigate])

 return (
  <CssVarsProvider>
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
     <Outlet />
    </Box>
   </Box>
  </CssVarsProvider>
 )
}

export default HomePage
