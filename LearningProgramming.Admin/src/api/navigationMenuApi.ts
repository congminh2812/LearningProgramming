import axiosClient, { withErrorHandling } from './axiosClient'

const NavigationMenuApi = {
 getNavigationMenus: withErrorHandling(async () => {
  var response = await axiosClient.get('/NavigationMenu/getNavigationMenus')
  return response.data
 }),
}

export default NavigationMenuApi
