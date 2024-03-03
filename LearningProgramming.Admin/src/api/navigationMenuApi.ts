import { CreateNavigationMenu, UpdateCreateNavigationMenu } from 'models/NavigationMenu'
import axiosClient, { withErrorHandling } from './axiosClient'

const NavigationMenuApi = {
 getNavigationMenus: withErrorHandling(async () => {
  var response = await axiosClient.get('/NavigationMenu/getNavigationMenus')
  return response.data
 }),

 getNavigationMenusByUserId: withErrorHandling(async () => {
  var response = await axiosClient.get('/NavigationMenu/getNavigationMenusByUserId')
  return response.data
 }),

 createNavigationMenu: withErrorHandling(async (data: CreateNavigationMenu) => {
  await axiosClient.post('/NavigationMenu/add', data)
 }),

 updateNavigationMenu: withErrorHandling(async (data: UpdateCreateNavigationMenu) => {
  await axiosClient.put(`/NavigationMenu/update/${data.id}`, data)
 }),

 deleteNavigationMenu: withErrorHandling(async (id: number) => {
  await axiosClient.delete(`/NavigationMenu/delete/${id}`)
 }),
}

export default NavigationMenuApi
