import { Snackbar } from '@mui/joy'
import { useSnackbar } from 'hooks/useSnackbar'

const CustomSnackbar = () => {
 const { isOpen, message, hideSnackbar } = useSnackbar()

 return (
  <Snackbar
   open={isOpen}
   autoHideDuration={6000}
   onClose={hideSnackbar}
  >
   {message}
  </Snackbar>
 )
}

export default CustomSnackbar
