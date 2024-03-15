import Sheet from '@mui/joy/Sheet'
import * as React from 'react'

import messageApi from 'api/messageApi'
import { ChatUser } from 'models/Message'
import ChatsPane from './components/ChatsPane'
import MessagesPane from './components/MessagesPane'

export default function MessagePage() {
 const [receiverId, setReceiverId] = React.useState<number>()
 const [chatUsers, setChatUsers] = React.useState<ChatUser[]>([])

 React.useEffect(() => {
  messageApi.getChatUsersByUserId().then((res: ChatUser[]) => {
   if (res) {
    setChatUsers(res)
    setReceiverId(res[0].receiverId)
   }
  })
 }, [])

 return (
  <Sheet
   sx={{
    flex: 1,
    width: '100%',
    mx: 'auto',
    pt: { xs: 'var(--Header-height)', sm: 0 },
    display: 'grid',
    gridTemplateColumns: {
     xs: '1fr',
     sm: 'minmax(min-content, min(30%, 400px)) 1fr',
    },
   }}
  >
   <Sheet
    sx={{
     position: { xs: 'fixed', sm: 'sticky' },
     transform: {
      xs: 'translateX(calc(100% * (var(--MessagesPane-slideIn, 0) - 1)))',
      sm: 'none',
     },
     transition: 'transform 0.4s, width 0.4s',
     zIndex: 100,
     width: '100%',
     top: 52,
    }}
   >
    <ChatsPane
     chats={chatUsers}
     receiverId={receiverId}
     setReceiverId={setReceiverId}
    />
   </Sheet>
   <MessagesPane receiverId={receiverId} receiver={chatUsers.find(x => x.receiverId === receiverId)} />
  </Sheet>
 )
}
