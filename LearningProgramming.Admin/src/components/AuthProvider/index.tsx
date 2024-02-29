import AuthApi from 'api/authApi'
import { TokenModel } from 'models/Auth'
import React, { createContext, useContext, useState, ReactNode, useEffect } from 'react'
import LocalStorageService from 'services/LocalStorageService'
import StorageKeys from 'utils/storage-key'
import { decodeAccessToken } from 'utils/token'

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
 const currentDate = new Date().getTime()
 const accessToken = LocalStorageService.get(StorageKeys.ACCESS_TOKEN)
 const refreshToken = LocalStorageService.get(StorageKeys.REFRESH_TOKEN)
 const accessTokenExpired = LocalStorageService.get(StorageKeys.ACCESS_TOKEN_EXPIRED) || '0'

 const [isLoggedIn, setIsLoggedIn] = useState<boolean>(parseInt(accessTokenExpired) * 1000 >= currentDate)

 useEffect(() => {
  if (!accessToken || !accessTokenExpired || !refreshToken) {
   setIsLoggedIn(false)
   return
  }

  if (parseInt(accessTokenExpired) * 1000 < currentDate) {
   AuthApi.getNewAccessToken(refreshToken)
    .then((res) => {
     setDataLocalStorage(res)
    })
    .catch(() => {
     logout()
    })
  }
 }, [accessToken, accessTokenExpired, refreshToken, currentDate])

 const login = (token: TokenModel) => {
  setDataLocalStorage(token)
 }

 const logout = () => {
  const persistent = LocalStorageService.get(StorageKeys.PERSISTENT) || 'false'
  if (persistent === 'false') LocalStorageService.set(StorageKeys.EMAIL, '')

  LocalStorageService.set(StorageKeys.ACCESS_TOKEN, '')
  LocalStorageService.set(StorageKeys.REFRESH_TOKEN, '')

  LocalStorageService.set(StorageKeys.USER_ID, '')
  LocalStorageService.set(StorageKeys.NAME, '')
  LocalStorageService.set(StorageKeys.ACCESS_TOKEN_EXPIRED, '')
  setIsLoggedIn(false)
 }

 const setDataLocalStorage = (token: TokenModel) => {
  const data = decodeAccessToken(token.accessToken)
  if (data) {
   LocalStorageService.set(StorageKeys.EMAIL, data.email)
   LocalStorageService.set(StorageKeys.USER_ID, data.sid)
   LocalStorageService.set(StorageKeys.NAME, data.name)
   LocalStorageService.set(StorageKeys.ACCESS_TOKEN_EXPIRED, data.exp)
  }
  LocalStorageService.set(StorageKeys.ACCESS_TOKEN, token.accessToken)
  LocalStorageService.set(StorageKeys.REFRESH_TOKEN, token.refreshToken)
  setIsLoggedIn(true)
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
