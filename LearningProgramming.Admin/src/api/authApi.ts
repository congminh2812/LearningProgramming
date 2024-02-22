import { LoginModel, RegisterModel } from 'models/Auth'
import axiosClient from './axiosClient'

const AuthApi = {
 login: async (model: LoginModel) => {
  const response = await axiosClient.post('/auth/login', model)

  return response.data
 },

 register: async (model: RegisterModel) => {
  const response = await axiosClient.post('/auth/register', model)

  return response.data
 },
}

export default AuthApi
