import { Sheet, Table, Typography } from '@mui/joy'
import { Kline } from 'models/Kline'
import moment from 'moment'
import { useEffect, useState } from 'react'
import klineSocket from 'sockets/socket'
import { TALib } from 'talib.ts'

const BinancePage = () => {
 const [currentPrice, setCurrentPrice] = useState(0)
 const [klines, setKlines] = useState<Kline[]>([])
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

 const timestampToString = (timestamp: number) => {
  const date = new Date(timestamp)

  return moment(date).format('DD/MM/YYYY HH:mm:ss')
 }

 return (
  <>
   <Typography color='warning'>Current price (SHIBA): {currentPrice} USDT</Typography>
   <Sheet sx={{ height: 'auto', overflow: 'auto' }}>
    <Table
     aria-label='table with sticky header'
     stickyHeader
     stickyFooter
     stripe='odd'
     hoverRow
    >
     <thead>
      <tr>
       <th>Open time</th>
       {/* <th>Open price</th>
      <th>High price</th>
      <th>Low price</th> */}
       <th>Close price</th>
       {/* <th>Volume (SHIBA)</th> */}
       {/* <th>Close time</th> */}
       {/* <th>Quote asset volume</th> */}
       {/* <th>Number of trades</th> */}
       {/* <th>Buy (SHIBA)</th> */}
       {/* <th>Buy (USDT)</th> */}
      </tr>
     </thead>
     <tbody>
      {klines.map((x: any, i: number) => (
       <tr key={i}>
        <td>{timestampToString(x.openTime)}</td>
        {/* <td>{x[1]}</td> */}
        {/* <td>{x[2]}</td> */}
        {/* <td>{x[3]}</td> */}
        <td>{x.closePrice}</td>
        {/* <td>{numberToText(Number(x[5]))}</td> */}
        {/* <td>{x[6]}</td> */}
        {/* <td>{x[7]}</td> */}
        {/* <td>{x[8]}</td> */}
        {/* <td>{numberToText(Number(x[9]))}</td> */}
        {/* <td>{numberToText(Number(x[10]))}</td> */}
       </tr>
      ))}
     </tbody>
    </Table>
   </Sheet>
  </>
 )
}

export default BinancePage
