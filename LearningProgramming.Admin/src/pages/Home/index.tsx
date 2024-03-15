import Box from '@mui/joy/Box'
import CssBaseline from '@mui/joy/CssBaseline'
import { CssVarsProvider } from '@mui/joy/styles'
import { Outlet } from 'react-router-dom'

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
  <CssVarsProvider>
   <CssBaseline />
   {/* <Box sx={{ display: 'flex', minHeight: '100dvh' }}>
    <Header />
    <Sidebar />
    <Box
     component='main'
     className='MainContent'
     sx={{
      display: 'flex',
      flexDirection: 'column',
      minWidth: 0,
      height: '100dvh',
      gap: 1,
     }}
    >
    </Box>
   </Box> */}
   <Box sx={{ display: 'flex', minHeight: '100dvh' }}>
    <Sidebar />
    <Header />
    <Box
     component='main'
     className='MainContent'
     sx={{ flex: 1 }}
    >
     <Outlet />
    </Box>
   </Box>
  </CssVarsProvider>
 )
}

export default HomePage
