import { withErrorHandling } from './axiosClient'
import axiosClientBinance from './axiosClientBinance'

const binanceApi = {
 market: {
  getKlines: withErrorHandling(async (symbol: string, interval: string) => {
   var data = await axiosClientBinance.get(`v3/klines?symbol=${symbol}&interval=${interval}&limit=100`)
   return data
  }),
 },
}

export default binanceApi
