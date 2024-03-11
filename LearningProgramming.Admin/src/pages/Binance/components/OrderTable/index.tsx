import { Sheet, Table } from '@mui/joy'
import { Order } from 'models/Order'
import React from 'react'

interface OrderTableProps {
 orders: Order[]
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
     </tr>
    </thead>
    <tbody>
     {orders.map((o) => (
      <tr key={o.orderId}>
       <td>{o.type}</td>
       <td>{o.side}</td>
       <td>{o.price}</td>
       <td>{o.quantity}</td>
      </tr>
     ))}
    </tbody>
   </Table>
  </Sheet>
 )
}

export default OrderTable
