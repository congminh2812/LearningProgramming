import { Box } from '@mui/joy'
import Card from '@mui/joy/Card'
import CardContent from '@mui/joy/CardContent'
import Typography from '@mui/joy/Typography'
import { Balance } from 'models/AccountInformation'

export interface AccountInformationProps {
 balances: Balance[]
}

export default function AccountInformation({ balances }: AccountInformationProps) {
 return (
  <Card
   variant='outlined'
   color='primary'
   invertedColors
  >
   <CardContent orientation='horizontal'>
    <CardContent>
     <Typography
      level='h3'
      color='primary'
     >
      Account Information
     </Typography>
     <Box sx={{ display: 'flex', flexDirection: 'row', gap: 2 }}>
      {balances.map((x) => (
       <Typography
        key={x.asset}
        level='body-md'
        color='primary'
       >
        {x.asset} {x.available.toFixed(2)}
       </Typography>
      ))}
     </Box>
    </CardContent>
   </CardContent>
  </Card>
 )
}
