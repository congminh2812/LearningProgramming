import Box from '@mui/joy/Box'
import Sheet from '@mui/joy/Sheet'
import Stack from '@mui/joy/Stack'
import messageApi from 'api/messageApi'
import { ChatUser, Message } from 'models/Message'
import * as React from 'react'
import LocalStorageService from 'services/LocalStorageService'
import AvatarWithStatus from '../AvatarWithStatus'
import MessageInput from '../MessageInput'
import MessagesPaneHeader from '../MessagesPaneHeader'
import ChatBubble from '../ChatBubble'

type MessagesPaneProps = {
 receiverId?: number
 receiver?: ChatUser
}

export default function MessagesPane({ receiverId, receiver }: MessagesPaneProps) {
 const [chatMessages, setChatMessages] = React.useState<Message[]>([])
 const [textAreaValue, setTextAreaValue] = React.useState('')

 React.useEffect(() => {
  messageApi
   .getMessagesByUserId()
   .then((res) => {
    if (res) setChatMessages(res)
   })
   .catch(() => {})
 }, [receiverId])

 const handleSendMessage = (content: string) => {
  const payload = {
   receiverId: receiver?.receiverId,
   senderId: LocalStorageService.getUserId(),
   content: content,
  }

  messageApi
   .addMessage(payload)
   .then((res: Message) => {
    if (res)
      setChatMessages([...chatMessages, res])
   })
   .catch(() => {})
 }

 return (
  <Sheet
   sx={{
    height: { xs: 'calc(100dvh - var(--Header-height))', lg: '100dvh' },
    display: 'flex',
    flexDirection: 'column',
    backgroundColor: 'background.level1',
   }}
  >
   <MessagesPaneHeader receiver={receiver} />
   <Box
    sx={{
     display: 'flex',
     flex: 1,
     minHeight: 0,
     px: 2,
     py: 3,
     overflowY: 'scroll',
     flexDirection: 'column-reverse',
    }}
   >
    <Stack
     spacing={2}
     justifyContent='flex-end'
    >
     {chatMessages.map((message: Message, index: number) => {
      const isYou = message.senderId === LocalStorageService.getUserId()
      return (
       <Stack
        key={index}
        direction='row'
        spacing={2}
        flexDirection={isYou ? 'row-reverse' : 'row'}
       >
        {!isYou && (
         <AvatarWithStatus
          online={true}
          src={receiver?.avatar}
         />
        )}
        <ChatBubble variant={isYou ? 'sent' : 'received'} message={message} />
       </Stack>
      )
     })}
    </Stack>
   </Box>
   <MessageInput
    textAreaValue={textAreaValue}
    setTextAreaValue={setTextAreaValue}
    onSubmit={() => {
      handleSendMessage(textAreaValue)
    }}
   />
  </Sheet>
 )
}
