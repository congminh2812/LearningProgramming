import { CreateBinanceOrder } from 'models/BinanceOrder'
import axiosClient, { withErrorHandling } from './axiosClient'

const binanceApi = {
 order: withErrorHandling(async (model: CreateBinanceOrder) => {
  var response = await axiosClient.post(`/Binance/order`, model)

  return response.data
 }),

 getAllOrders: withErrorHandling(async (symbol: string, limit: number) => {
  var response = await axiosClient.get(`/Binance/getAllOrders?symbol=${symbol}&limit=${limit}`)

  return response.data
 }),

 getAccountInformation: withErrorHandling(async () => {
  var response = await axiosClient.get(`/Binance/getAccountInformation`)

  return response.data
 }),

 getKlines: withErrorHandling(async (symbol: string, interval: number, limit: number) => {
  var response = await axiosClient.get(`/Binance/getKlines?symbol=${symbol}&interval=${interval}&limit=${limit}`)

  return response.data
 }),
}

export default binanceApi
