import { TokenModel } from 'models/Auth'
import React, { createContext, useContext, useState, ReactNode, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import LocalStorageService from 'services/LocalStorageService'

interface AuthContextType {
 isLoggedIn: boolean
 login: (token: TokenModel) => void
 logout: () => void
}

const AuthContext = createContext<AuthContextType | undefined>(undefined)

interface AuthProviderProps {
 children: ReactNode
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
 const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false)

 useEffect(() => {
  const accessToken = LocalStorageService.get('accessToken')
  setIsLoggedIn(accessToken !== undefined)
 }, [])

 const login = (token: TokenModel) => {
  console.log(parseAccessToken(token.accessToken))
  LocalStorageService.set('accessToken', token.accessToken)
  LocalStorageService.set('refreshToken', token.refreshToken)
  setIsLoggedIn(true)
 }

 const logout = () => {
  LocalStorageService.set('accessToken', '')
  LocalStorageService.set('refreshToken', '')
  setIsLoggedIn(false)
 }

 const value: AuthContextType = {
  isLoggedIn,
  login,
  logout,
 }

 return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>
}

export const useAuth = (): AuthContextType => {
 const context = useContext(AuthContext)
 if (!context) {
  throw new Error('useAuth must be used within an AuthProvider')
 }
 return context
}

const parseAccessToken = (accessToken: string): { [key: string]: any } | null => {
 try {
  const payloadBase64 = accessToken.split('.')[1]
  const decodedPayload = atob(payloadBase64)
  const parsedPayload = JSON.parse(decodedPayload)
  return parsedPayload
 } catch (error) {
  console.error('Error parsing access token:', error)
  return null
 }
}
