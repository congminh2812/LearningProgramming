import './App.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import NotFound from 'pages/NotFound'
import LoginPage from 'pages/Login'
import { AuthProvider } from 'components/AuthProvider'
import HomePage from 'pages/Home'
import UsersPage from 'pages/Users'
import ProfilePage from 'pages/Users/Profile'
import DashboardPage from 'pages/Dashboard'
import { SnackbarProvider } from 'components/SnackbarProvider'
import CustomSnackbar from 'components/CustomSnackbar'

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
    ],
   },
  ],
 },
 {
  path: '*',
  element: <NotFound />,
 },
])

function App() {
 return (
  <>
   <AuthProvider>
    <SnackbarProvider>
     <RouterProvider router={router} />
     <CustomSnackbar />
    </SnackbarProvider>
   </AuthProvider>
  </>
 )
}

export default App
