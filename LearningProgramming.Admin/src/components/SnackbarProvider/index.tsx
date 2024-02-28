import { ReactNode, createContext, useState } from 'react'

interface SnackbarContextType {
 isOpen: boolean
 message: string
 showSnackbar: (msg: string) => void
 hideSnackbar: () => void
}

interface SnackbarProviderProps {
 children: ReactNode
}

export const SnackbarContext = createContext<SnackbarContextType>({
 isOpen: false,
 message: '',
 showSnackbar: (msg) => {},
 hideSnackbar: () => {},
})

export const SnackbarProvider = ({ children }: SnackbarProviderProps) => {
 const [isOpen, setIsOpen] = useState(false)
 const [message, setMessage] = useState('')

 const showSnackbar = (msg: string) => {
  setMessage(msg)
  setIsOpen(true)
 }

 const hideSnackbar = () => {
  setIsOpen(false)
 }

 return (
  <SnackbarContext.Provider value={{ isOpen, message, showSnackbar, hideSnackbar }}>
   {children}
  </SnackbarContext.Provider>
 )
}
