import axiosClient, { withErrorHandling } from './axiosClient'
import axiosClientBinance from './axiosClientBinance'

const binanceApi = {
 market: {
  getKlines: withErrorHandling(async (symbol: string, interval: string, limit: number = 10) => {
   var data = await axiosClientBinance.get(`v3/klines?symbol=${symbol}&interval=${interval}&limit=${limit}`)
   return data
  }),
 },
 trade: {
  getAllOrders: withErrorHandling(async (symbol: string) => {
   var data = await axiosClientBinance.get(
    `v3/allOrders?symbol=${symbol}&timestamp=${Date.now()}&signature=${process.env.REACT_APP_BINANCE_SIGNATURE}`,
   )
   return data
  }),
  newOrder: withErrorHandling(async (symbol: string, side: string, type: string, quantity: number) => {
   var data = await axiosClientBinance.post(
    `v3/order?symbol=${symbol}&side=${side}&type=${type}&quantity=${quantity}&timestamp=${Date.now()}&signature=${
     process.env.REACT_APP_BINANCE_SIGNATURE
    }`,
   )
   return data
  }),
 },

 getAllOrders: withErrorHandling(async (symbol: string, limit: number) => {
  var response = await axiosClient.get(`/Binance/getAllOrders?symbol=${symbol}&limit=${limit}`)

  return response.data
 }),

 getAccountInformation: withErrorHandling(async () => {
  var response = await axiosClient.get(`/Binance/getAccountInformation`)

  return response.data
 }),
}

export default binanceApi
