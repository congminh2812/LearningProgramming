import { Sheet, Table, Typography } from '@mui/joy'
import { Kline } from 'models/Kline'
import { Order } from 'models/Order'
import moment from 'moment'
import { useEffect, useState } from 'react'
import klineSocket from 'sockets/socket'
import { TALib } from 'talib.ts'
import OrderTable from './components/OrderTable'
import binanceApi from 'api/binanceApi'

const BinancePage = () => {
 const [currentPrice, setCurrentPrice] = useState(0)
 const [klines, setKlines] = useState<Kline[]>([])
 const [orders, setOrders] = useState<Order[]>([])
 const [isInterupt, setIsInterupt] = useState(false)

 useEffect(() => {
  klineSocket.onmessage = (event) => {
   const data = JSON.parse(event.data)
   const first = klines[0]
   const newKline = { openTime: data.k.t, closePrice: data.k.c }

   if (!first || first.openTime !== newKline.openTime) {
    klines.unshift(newKline)
    // const newKlines = [newKline, ...klines]
    if (klines.length >= 34) {
     klines.pop()

     const sma13 = TALib.sma(klines.map((x) => Number(x.closePrice)).slice(0, 13), 13)
     const sma34 = TALib.sma(klines.map((x) => Number(x.closePrice)).slice(0, 34), 34)

     console.log(sma13.sma.getValue()[12]?.toFixed(8), sma34.sma.getValue()[33]?.toFixed(8))

     const number1 = Number(sma13.sma.getValue()[12]?.toFixed(8))
     const number2 = Number(sma13.sma.getValue()[33]?.toFixed(8))

     if (number1 === number2) setIsInterupt(true)

     if (isInterupt) {
      if (number1 > number2) {
       // order buy coin
      } else {
       // order sell coin
      }
     }
    }

    setKlines([...klines])
   }

   setCurrentPrice(data.k.c)
  }
 })

 useEffect(() => {
  binanceApi.trade
   .getAllOrders('SHIBUSDT')
   .then((res) => {
    if (res.length > 0) setOrders(res)
   })
   .catch(() => {})
 }, [])

 return (
  <>
   <Typography color='warning'>Current price (SHIBA): {currentPrice} USDT</Typography>
   <OrderTable orders={orders} />
  </>
 )
}

export default BinancePage
