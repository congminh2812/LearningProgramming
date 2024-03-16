import { Sheet, Table } from '@mui/joy'
import { BinanceOrder } from 'models/BinanceOrder'
import Constants from 'utils/constants'
import { dateFormat } from 'utils/date-format'
import { numberToText } from 'utils/number-format'

interface OrderTableProps {
 orders: BinanceOrder[]
}
const OrderTable = ({ orders }: OrderTableProps) => {
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
      <th>Type</th>
      <th>Side</th>
      <th>Price</th>
      <th>Quantity</th>
      <th>Time</th>
     </tr>
    </thead>
    <tbody>
     {orders.map((o) => (
      <tr key={o.clientOrderId}>
       <td>{Constants.BinanceTypes[Number(o.type)]}</td>
       <td>{Constants.BinanceSides[Number(o.side)]}</td>
       <td>{o.price}</td>
       <td>{numberToText(o.quantity)}</td>
       <td>{dateFormat(o.createTime, 'DD/MM/YYYY HH:mm')}</td>
      </tr>
     ))}
    </tbody>
   </Table>
  </Sheet>
 )
}

export default OrderTable
