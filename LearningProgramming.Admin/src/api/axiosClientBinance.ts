import axios from 'axios'

const axiosClientBinance = axios.create({
 baseURL: process.env.REACT_APP_BINANCE_URL,
 //  timeout: 10000,
 headers: { 'Content-Type': 'application/json' },
})

axiosClientBinance.interceptors.request.use(
 function (config) {
  return config
 },
 function (error) {
  return Promise.reject(error)
 },
)

axiosClientBinance.interceptors.response.use(
 function (response) {
  return response.data
 },
 function (error) {
  return Promise.reject(error)
 },
)

export default axiosClientBinance
