import React from 'react'
import './App.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import NotFound from 'pages/NotFound'
import LoginPage from 'pages/Login'
import DashboardPage from 'pages/Dashboard'
import { AuthProvider } from 'components/AuthProvider'

const router = createBrowserRouter([
 {
  path: '/login',
  element: <LoginPage />,
 },
 {
  path: '/dashboard',
  element: <DashboardPage />,
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
    <RouterProvider router={router} />
   </AuthProvider>
  </>
 )
}

export default App
