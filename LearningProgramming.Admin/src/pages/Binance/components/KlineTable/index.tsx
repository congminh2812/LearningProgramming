import { Sheet, Table } from '@mui/joy'
import { Kline } from 'models/Kline'
import moment from 'moment'

interface KlineTableProps {
 klines: Kline[]
}
const KlineTable = ({ klines }: KlineTableProps) => {
 const timestampToString = (timestamp: number) => {
  const date = new Date(timestamp)

  return moment(date).format('DD/MM/YYYY HH:mm:ss')
 }

 return (
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
 )
}

export default KlineTable
