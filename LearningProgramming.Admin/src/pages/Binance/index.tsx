import { Sheet, Table } from '@mui/joy'
import binanceApi from 'api/binanceApi'
import moment from 'moment'
import { useEffect, useState } from 'react'

const BinancePage = () => {
 const [klines, setKlines] = useState([])
 useEffect(() => {
  binanceApi.market.getKlines('SHIBUSDT', '15m').then((data: any) => {
   if (data.length > 0) setKlines(data.slice().reverse())
  })
 }, [])

 const timestampToString = (timestamp: number) => {
  const date = new Date(timestamp)
  //   date.setHours(date.getHours())

  return moment(date).format('DD/MM/YYYY HH:mm')
 }

 return (
  <>
   <Sheet sx={{ height: 600, overflow: 'auto' }}>
    <Table
     aria-label='table with sticky header'
     stickyHeader
     stickyFooter
     stripe='odd'
     hoverRow
    >
     <thead>
      <th>Open time</th>
      {/* <th>Open price</th>
      <th>High price</th>
      <th>Low price</th> */}
      <th>Close price</th>
      <th>Volume</th>
      {/* <th>Close time</th> */}
      {/* <th>Quote asset volume</th> */}
      {/* <th>Number of trades</th> */}
      <th>Taker buy base asset volume</th>
      <th>Taker buy quote asset volume</th>
     </thead>
     <tbody>
      {klines.map((x: any) => (
       <tr>
        <td>{timestampToString(x[0])}</td>
        {/* <td>{x[1]}</td> */}
        {/* <td>{x[2]}</td> */}
        {/* <td>{x[3]}</td> */}
        <td>{x[4]}</td>
        <td>{x[5]}</td>
        {/* <td>{x[6]}</td> */}
        {/* <td>{x[7]}</td> */}
        {/* <td>{x[8]}</td> */}
        <td>{x[9]}</td>
        <td>{x[10]}</td>
       </tr>
      ))}
     </tbody>
    </Table>
   </Sheet>
  </>
 )
}

export default BinancePage
