import { useColorScheme } from '@mui/joy'
import { AuthProvider } from 'components/AuthProvider'
import DashboardPage from 'pages/Dashboard'
import HomePage from 'pages/Home'
import LoginPage from 'pages/Login'
import NavigationMenuPage from 'pages/NavigationMenu'
import NotFound from 'pages/NotFound'
import UsersPage from 'pages/Users'
import ProfilePage from 'pages/Users/Profile'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import './App.css'
import './websocket/account'
import ListUserPage from 'pages/Users/ListUser'

const router = createBrowserRouter([
 {
  path: '/login',
  element: <LoginPage />,
 },
 {
  path: '/',
  element: <HomePage />,
  children: [
   {
    path: '/',
    element: <DashboardPage />,
   },
   {
    path: '/users',
    element: <UsersPage />,
    children: [
     {
      path: '/users/profile',
      element: <ProfilePage />,
     },
     {
      path: '/users/list-user',
      element: <ListUserPage />,
     },
    ],
   },
   {
    path: '/navigation-menu',
    element: <NavigationMenuPage />,
   },
  ],
 },

 {
  path: '*',
  element: <NotFound />,
 },
])

function App() {
 const { mode } = useColorScheme()

 return (
  <AuthProvider>
   <RouterProvider router={router} />
   <ToastContainer
    position='bottom-right'
    autoClose={3000}
    hideProgressBar={false}
    newestOnTop={false}
    closeOnClick
    rtl={false}
    pauseOnFocusLoss
    pauseOnHover
    theme={mode}
   />
  </AuthProvider>
 )
}

export default App
