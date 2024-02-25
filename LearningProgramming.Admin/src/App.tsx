import React from 'react'
import './App.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import NotFound from 'pages/NotFound'
import LoginPage from 'pages/Login'
import { AuthProvider } from 'components/AuthProvider'
import HomePage from 'pages/Home'

const router = createBrowserRouter([
 {
  path: '/login',
  element: <LoginPage />,
 },
 {
  path: '/',
  element: <HomePage />,
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
