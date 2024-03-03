import { WarningRounded } from '@mui/icons-material'
import { Button, Modal, Sheet, Stack, Typography } from '@mui/joy'

interface ConfirmDeleteProps {
 open: boolean
 setOpen: (open: boolean) => void
 onConfirm: () => void
}

const ConfirmDelete = ({ open, setOpen, onConfirm }: ConfirmDeleteProps) => {
 return (
  <Modal
   aria-labelledby='modal-title'
   aria-describedby='modal-desc'
   open={open}
   sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
  >
   <Sheet
    variant='outlined'
    sx={{
     maxWidth: 500,
     borderRadius: 'md',
     p: 3,
     boxShadow: 'lg',
    }}
   >
    <Typography
     component='h2'
     id='modal-title'
     level='h4'
     textColor='inherit'
     fontWeight='lg'
     mb={1}
    >
     <WarningRounded
      sx={{ verticalAlign: 'middle', marginRight: 1 }}
      color='warning'
     />
     Are you sure to delete?
    </Typography>
    <Typography
     id='modal-desc'
     textColor='text.tertiary'
    >
     This content after deleting won't be able to restore again?
    </Typography>
    <Stack
     sx={{ marginTop: 2 }}
     direction='row'
     justifyContent='right'
     spacing={1}
    >
     <Button
      type='button'
      onClick={onConfirm}
     >
      Ok
     </Button>
     <Button
      type='button'
      onClick={() => setOpen(false)}
      color='neutral'
      variant='outlined'
     >
      Cancel
     </Button>
    </Stack>
   </Sheet>
  </Modal>
 )
}

export default ConfirmDelete
