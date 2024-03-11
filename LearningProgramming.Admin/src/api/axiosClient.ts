import axios from 'axios'
import LocalStorageService from 'services/LocalStorageService'
import StorageKeys from 'utils/storage-key'
import { decodeAccessToken } from 'utils/token'
import AuthApi from './authApi'
import { toast } from 'react-toastify'

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
  if (error.response && !error.config.url.includes('getNewAccessToken') && error.response.status === 401) {
   const refreshToken = LocalStorageService.get(StorageKeys.REFRESH_TOKEN)
   AuthApi.getNewAccessToken(refreshToken)
    .then((res) => {
     const data = decodeAccessToken(res.accessToken)
     if (data) LocalStorageService.set(StorageKeys.ACCESS_TOKEN_EXPIRED, data.exp)
     LocalStorageService.set(StorageKeys.ACCESS_TOKEN, res.accessToken)

     return axiosClient(error.config)
    })
    .catch(() => {
     window.location.href = '/login'
    })

   return Promise.resolve({ data: [] })
  }

  return Promise.reject(error)
 },
)

export const withErrorHandling = (apiMethod: any) => {
 return async (...args: any[]) => {
  try {
   const result = await apiMethod(...args)
   return result
  } catch (error: any) {
   console.log(error)
   toast.error(error.response.data.title)
   throw error
  }
 }
}

export default axiosClient
