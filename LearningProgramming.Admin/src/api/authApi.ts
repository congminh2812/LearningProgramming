import { LoginModel, RegisterModel } from 'models/Auth'
import axiosClient, { withErrorHandling } from './axiosClient'

const AuthApi = {
 login: withErrorHandling(async (model: LoginModel) => {
  const response = await axiosClient.post('/auth/login', model)
  return response.data
 }),

 register: withErrorHandling(async (model: RegisterModel) => {
  const response = await axiosClient.post('/auth/register', model)
  return response.data
 }),

 getNewAccessToken: withErrorHandling(async (refreshToken: string) => {
  const response = await axiosClient.get(`/auth/getNewAccessToken?refreshToken=${refreshToken}`)
  return response.data
 }),
}

export default AuthApi
