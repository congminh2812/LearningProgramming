import { Chip, Grid, Sheet, Table } from '@mui/joy'
import { BinanceOrder } from 'models/BinanceOrder'
import { dateFormat } from 'utils/date-format'
import { BinanceSideEnum } from 'utils/enums/binance-enum'
import { numberToText } from 'utils/number-format'

interface OrderTableProps {
 orders: BinanceOrder[]
}
const OrderTable = ({ orders }: OrderTableProps) => {
 return (
  <Sheet
   variant='outlined'
   color='neutral'
   sx={{ height: 'auto', overflow: 'auto', mt: 1, p: 1 }}
  >
   <Grid container>
    <Grid xs={6}>
     <Chip
      variant='soft'
      color='success'
     >
      BUY
     </Chip>
     <Table
      aria-label='table with sticky header'
      stickyHeader
      stickyFooter
      hoverRow
     >
      <thead>
       <tr>
        <th>Time</th>
        <th>Price</th>
        <th>Quantity</th>
       </tr>
      </thead>
      <tbody>
       {orders
        .filter((x) => x.side === BinanceSideEnum.BUY)
        .map((o) => (
         <tr key={o.clientOrderId}>
          <td>{dateFormat(o.createTime, 'DD/MM/YYYY HH:mm')}</td>
          <td>{o.price}</td>
          <td>{numberToText(o.quantity)}</td>
         </tr>
        ))}
      </tbody>
     </Table>
    </Grid>
    <Grid xs={6}>
     <Chip
      variant='soft'
      color='danger'
     >
      SELL
     </Chip>
     <Table
      aria-label='table with sticky header'
      stickyHeader
      stickyFooter
      hoverRow
     >
      <thead>
       <tr>
        <th>Time</th>
        <th>Price</th>
        <th>Quantity</th>
       </tr>
      </thead>
      <tbody>
       {orders
        .filter((x) => x.side === BinanceSideEnum.SELL)
        .map((o) => (
         <tr key={o.clientOrderId}>
          <td>{dateFormat(o.createTime, 'DD/MM/YYYY HH:mm')}</td>
          <td>{o.price}</td>
          <td>{numberToText(o.quantity)}</td>
         </tr>
        ))}
      </tbody>
     </Table>
    </Grid>
   </Grid>
  </Sheet>
 )
}

export default OrderTable
