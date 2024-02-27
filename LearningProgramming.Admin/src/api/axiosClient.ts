import axios from 'axios'
import LocalStorageService from 'services/LocalStorageService'
import StorageKeys from 'utils/storage-key'
import AuthApi from './authApi'
import { decodeAccessToken } from 'utils/token'
import { Navigate } from 'react-router-dom'

const axiosClient = axios.create({
 baseURL: process.env.REACT_APP_BASE_URL,
 //  timeout: 10000,
 headers: { 'Content-Type': 'application/json' },
})

axiosClient.interceptors.request.use(
 function (config) {
  const accessToken = LocalStorageService.get(StorageKeys.ACCESS_TOKEN)
  if (accessToken) {
   config.headers.Authorization = `Bearer ${accessToken}`
  }

  return config
 },
 function (error) {
  return Promise.reject(error)
 },
)

// Add a response interceptor
axiosClient.interceptors.response.use(
 function (response) {
  return response
 },
 function (error) {
  if (error.response.status === 401) {
   error.config._isRetry = true
   const refreshToken = LocalStorageService.get(StorageKeys.REFRESH_TOKEN)
   AuthApi.getNewAccessToken(refreshToken)
    .then((res) => {
     const data = decodeAccessToken(res.accessToken)
     if (data) LocalStorageService.set(StorageKeys.ACCESS_TOKEN_EXPIRED, data.exp)
     LocalStorageService.set(StorageKeys.ACCESS_TOKEN, res.accessToken)

     return axiosClient(error.config)
    })
    .catch((e) => {
     Navigate({ to: '/login' })
    })
  }
  return Promise.reject(error)
 },
)

export const withErrorHandling = (apiMethod: any) => {
 return async (...args: any[]) => {
  try {
   const result = await apiMethod(...args)
   return result
  } catch (error) {
   console.error('Error:', error)
   throw error
  }
 }
}

export default axiosClient
