import { withErrorHandling } from './axiosClient'
import axiosClientBinance from './axiosClientBinance'

const binanceApi = {
 market: {
  getKlines: withErrorHandling(async (symbol: string, interval: string, limit: number = 10) => {
   var data = await axiosClientBinance.get(`v3/klines?symbol=${symbol}&interval=${interval}&limit=${limit}`)
   return data
  }),
 },
}

export default binanceApi
