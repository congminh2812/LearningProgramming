import { Box, Chip } from '@mui/joy'
import binanceApi from 'api/binanceApi'
import binanceHub from 'hubs/binance-hub'
import { Balance } from 'models/AccountInformation'
import { BinanceOrder } from 'models/BinanceOrder'
import { useEffect, useState } from 'react'
import AccountInformation from './components/AccountInformation'
import OrderTable from './components/OrderTable'

const BinancePage = () => {
 const [price, setPrice] = useState<number>(0)
 const [orders, setOrders] = useState<BinanceOrder[]>([])
 const [balances, setBalances] = useState<Balance[]>([])
 const [refreshAcountInfo, setRefreshAccountInfo] = useState<boolean>(false)

 useEffect(() => {
  binanceApi
   .getAllOrders('BOMEUSDT', 10)
   .then((res) => {
    if (res.length > 0) setOrders(res)
   })
   .catch(() => {})
 }, [])

 useEffect(() => {
  binanceApi
   .getAccountInformation()
   .then((res) => {
    if (res) setBalances(res.balances)
   })
   .catch(() => {})
 }, [refreshAcountInfo])

 useEffect(() => {
  binanceHub.init()
  binanceHub.onOrder((order: any) => {
   if (order) {
    const newOrder: BinanceOrder = {
     side: order.side,
     price: order.price,
     quantity: order.quantity,
     createTime: order.createTime,
    }
    setOrders((o) => [newOrder, ...o.filter((_, i) => (o.length === 10 && i !== o.length - 1) || o.length < 10)])
    setRefreshAccountInfo((v) => !v)
   }
  })

  binanceHub.onPrices((kline: any) => {
   if (kline) {
    setPrice(kline.closePrice)
   }
  })

  return () => {
   binanceHub.onStop()
  }
 }, [])

 return (
  <Box sx={{ p: 3 }}>
   <AccountInformation balances={balances} />
   <Chip
    variant='outlined'
    sx={{ mt: 1 }}
   >
    BOME: {price}
   </Chip>
   <OrderTable orders={orders} />
  </Box>
 )
}

export default BinancePage
