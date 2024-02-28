import { SnackbarContext } from 'components/SnackbarProvider'
import { useContext } from 'react'

export const useSnackbar = () => useContext(SnackbarContext)
