import CircleIcon from '@mui/icons-material/Circle'
import Box from '@mui/joy/Box'
import ListDivider from '@mui/joy/ListDivider'
import ListItem from '@mui/joy/ListItem'
import ListItemButton, { ListItemButtonProps } from '@mui/joy/ListItemButton'
import Stack from '@mui/joy/Stack'
import Typography from '@mui/joy/Typography'
import { ChatUser } from 'models/Message'
import { toggleMessagesPane } from 'pages/Message/utils'
import * as React from 'react'
import AvatarWithStatus from '../AvatarWithStatus'

type ChatListItemProps = ListItemButtonProps & {
 chatUser: ChatUser
 selected: boolean
 onClick: () => void
}

export default function ChatListItem(props: ChatListItemProps) {
 const { chatUser, selected, onClick } = props
 return (
  <React.Fragment>
   <ListItem>
    <ListItemButton
     onClick={() => {
      toggleMessagesPane()
      onClick()
     }}
     selected={selected}
     color='neutral'
     sx={{
      flexDirection: 'column',
      alignItems: 'initial',
      gap: 1,
     }}
    >
     <Stack
      direction='row'
      spacing={1.5}
     >
      <AvatarWithStatus
       online={false}
       src={chatUser.avatar}
      />
      <Box sx={{ flex: 1 }}>
       <Typography level='title-sm'>{chatUser.fullName}</Typography>
       <Typography
        level='body-sm'
        sx={{
         display: '-webkit-box',
         WebkitLineClamp: '2',
         WebkitBoxOrient: 'vertical',
         overflow: 'hidden',
         textOverflow: 'ellipsis',
        }}
       >
        {chatUser.content ?? 'Not message yet'}
       </Typography>
      </Box>
      <Box
       sx={{
        lineHeight: 1.5,
        textAlign: 'right',
       }}
      >
       {chatUser.unread && (
        <CircleIcon
         sx={{ fontSize: 12 }}
         color='primary'
        />
       )}
      </Box>
     </Stack>
    </ListItemButton>
   </ListItem>
   <ListDivider sx={{ margin: 0 }} />
  </React.Fragment>
 )
}
