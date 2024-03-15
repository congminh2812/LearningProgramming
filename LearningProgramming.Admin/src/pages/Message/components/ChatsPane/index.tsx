import CloseRoundedIcon from '@mui/icons-material/CloseRounded';
import EditNoteRoundedIcon from '@mui/icons-material/EditNoteRounded';
import SearchRoundedIcon from '@mui/icons-material/SearchRounded';
import { Box, Chip, IconButton, Input } from '@mui/joy';
import List from '@mui/joy/List';
import Sheet from '@mui/joy/Sheet';
import Stack from '@mui/joy/Stack';
import Typography from '@mui/joy/Typography';
import { ChatUser } from 'models/Message';
import { toggleMessagesPane } from 'pages/Message/utils';
import ChatListItem from '../ChatListItem';

type ChatsPaneProps = {
  chats: ChatUser[];
  setReceiverId: (id: number) => void;
  receiverId?: number;
};

export default function ChatsPane({chats = [], setReceiverId, receiverId}: ChatsPaneProps) {
  const countMessageUnread = chats.filter(x => x.unread).length
  const handClick = (id: number) => {
    setReceiverId(id)
  }
  
  return (
    <Sheet
      sx={{
        borderRight: '1px solid',
        borderColor: 'divider',
        height: 'calc(100dvh - var(--Header-height))',
        overflowY: 'auto',
      }}
    >
      <Stack
        direction="row"
        spacing={1}
        alignItems="center"
        justifyContent="space-between"
        p={2}
        pb={1.5}
      >
        <Typography
          fontSize={{ xs: 'md', md: 'lg' }}
          component="h1"
          fontWeight="lg"
          endDecorator={
            <Chip
              variant="soft"
              color="primary"
              size="md"
              slotProps={{ root: { component: 'span' } }}
            >
              {countMessageUnread === 0 ? '' : countMessageUnread}
            </Chip>
          }
          sx={{ mr: 'auto' }}
        >
          Messages
        </Typography>
        <IconButton
          variant="plain"
          aria-label="edit"
          color="neutral"
          size="sm"
          sx={{ display: { xs: 'none', sm: 'unset' } }}
        >
          <EditNoteRoundedIcon />
        </IconButton>
        <IconButton
          variant="plain"
          aria-label="edit"
          color="neutral"
          size="sm"
          onClick={() => {
            toggleMessagesPane();
          }}
          sx={{ display: { sm: 'none' } }}
        >
          <CloseRoundedIcon />
        </IconButton>
      </Stack>
      <Box sx={{ px: 2, pb: 1.5 }}>
        <Input
          size="sm"
          startDecorator={<SearchRoundedIcon />}
          placeholder="Search"
          aria-label="Search"
        />
      </Box>
      <List
        sx={{
          py: 0,
          '--ListItem-paddingY': '0.75rem',
          '--ListItem-paddingX': '1rem',
        }}
      >
        {chats.map((chat) => (
          <ChatListItem
            key={chat.receiverId}
            chatUser={chat}
            selected={receiverId === chat.receiverId}
            onClick={() => handClick(chat.receiverId)}
          />
        ))}
      </List>
    </Sheet>
  );
}