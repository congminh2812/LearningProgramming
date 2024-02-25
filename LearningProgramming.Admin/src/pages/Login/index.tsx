import BadgeRoundedIcon from '@mui/icons-material/BadgeRounded'
import Box from '@mui/joy/Box'
import Button from '@mui/joy/Button'
import Checkbox from '@mui/joy/Checkbox'
import CssBaseline from '@mui/joy/CssBaseline'
import Divider from '@mui/joy/Divider'
import FormControl from '@mui/joy/FormControl'
import FormLabel, { formLabelClasses } from '@mui/joy/FormLabel'
import GlobalStyles from '@mui/joy/GlobalStyles'
import IconButton from '@mui/joy/IconButton'
import Input from '@mui/joy/Input'
import Link from '@mui/joy/Link'
import Stack from '@mui/joy/Stack'
import SvgIcon from '@mui/joy/SvgIcon'
import Typography from '@mui/joy/Typography'
import { CssVarsProvider } from '@mui/joy/styles'
import AuthApi from 'api/authApi'
import { useAuth } from 'components/AuthProvider'
import ColorSchemeToggle from 'components/ColorSchemeToggle'
import { LoginModel } from 'models/Auth'
import { useNavigate } from 'react-router-dom'
import React, { useEffect, useState } from 'react'
import { CircularProgress } from '@mui/joy'
import LocalStorageService from 'services/LocalStorageService'
import StorageKeys from 'utils/storage-key'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'

const GoogleIcon = () => {
 return (
  <SvgIcon fontSize='xl'>
   <g transform='matrix(1, 0, 0, 1, 27.009001, -39.238998)'>
    <path
     fill='#4285F4'
     d='M -3.264 51.509 C -3.264 50.719 -3.334 49.969 -3.454 49.239 L -14.754 49.239 L -14.754 53.749 L -8.284 53.749 C -8.574 55.229 -9.424 56.479 -10.684 57.329 L -10.684 60.329 L -6.824 60.329 C -4.564 58.239 -3.264 55.159 -3.264 51.509 Z'
    />
    <path
     fill='#34A853'
     d='M -14.754 63.239 C -11.514 63.239 -8.804 62.159 -6.824 60.329 L -10.684 57.329 C -11.764 58.049 -13.134 58.489 -14.754 58.489 C -17.884 58.489 -20.534 56.379 -21.484 53.529 L -25.464 53.529 L -25.464 56.619 C -23.494 60.539 -19.444 63.239 -14.754 63.239 Z'
    />
    <path
     fill='#FBBC05'
     d='M -21.484 53.529 C -21.734 52.809 -21.864 52.039 -21.864 51.239 C -21.864 50.439 -21.724 49.669 -21.484 48.949 L -21.484 45.859 L -25.464 45.859 C -26.284 47.479 -26.754 49.299 -26.754 51.239 C -26.754 53.179 -26.284 54.999 -25.464 56.619 L -21.484 53.529 Z'
    />
    <path
     fill='#EA4335'
     d='M -14.754 43.989 C -12.984 43.989 -11.404 44.599 -10.154 45.789 L -6.734 42.369 C -8.804 40.429 -11.514 39.239 -14.754 39.239 C -19.444 39.239 -23.494 41.939 -25.464 45.859 L -21.484 48.949 C -20.534 46.099 -17.884 43.989 -14.754 43.989 Z'
    />
   </g>
  </SvgIcon>
 )
}

export default function LoginPage() {
 const email = LocalStorageService.get(StorageKeys.EMAIL) || ''
 const password = LocalStorageService.get(StorageKeys.PASSWORD) || ''
 const persistent = LocalStorageService.get(StorageKeys.PERSISTENT) || 'false'
 const [loading, setLoading] = useState(false)
 const navigate = useNavigate()
 const auth = useAuth()
 const { handleSubmit, register, control } = useForm({
  defaultValues: { email, password, persistent: persistent === 'true' },
 })

 useEffect(() => {
  if (auth.isLoggedIn) {
   navigate('/')
  }
 }, [auth.isLoggedIn, navigate])

 const onSubmit: SubmitHandler<LoginModel> = (data) => {
  setLoading(true)
  AuthApi.login(data).then((res) => {
   setLoading(false)
   auth.login(res)

   LocalStorageService.set(StorageKeys.PERSISTENT, data.persistent ? 'true' : 'false')
   if (data.persistent) LocalStorageService.set(StorageKeys.PASSWORD, data.password)

   navigate('/')
  })
 }

 if (auth.isLoggedIn)
  return (
   <Box
    width={'100vw'}
    height={'100vh'}
    display={'flex'}
    alignItems={'center'}
    justifyContent={'center'}
   >
    <CircularProgress variant='solid' />
   </Box>
  )

 return (
  <CssVarsProvider
   defaultMode='dark'
   disableTransitionOnChange
  >
   <CssBaseline />
   <GlobalStyles
    styles={{
     ':root': {
      '--Collapsed-breakpoint': '769px', // form will stretch when viewport is below `769px`
      '--Cover-width': '50vw', // must be `vw` only
      '--Form-maxWidth': '800px',
      '--Transition-duration': '0.4s', // set to `none` to disable transition
     },
    }}
   />
   <Box
    sx={(theme) => ({
     width: 'clamp(100vw - var(--Cover-width), (var(--Collapsed-breakpoint) - 100vw) * 999, 100vw)',
     transition: 'width var(--Transition-duration)',
     transitionDelay: 'calc(var(--Transition-duration) + 0.1s)',
     position: 'relative',
     zIndex: 1,
     display: 'flex',
     justifyContent: 'flex-end',
     backdropFilter: 'blur(12px)',
     backgroundColor: 'rgba(255 255 255 / 0.2)',
     [theme.getColorSchemeSelector('dark')]: {
      backgroundColor: 'rgba(19 19 24 / 0.4)',
     },
    })}
   >
    <Box
     sx={{
      display: 'flex',
      flexDirection: 'column',
      minHeight: '100dvh',
      width: 'clamp(var(--Form-maxWidth), (var(--Collapsed-breakpoint) - 100vw) * 999, 100%)',
      maxWidth: '100%',
      px: 2,
     }}
    >
     <Box
      component='header'
      sx={{
       py: 3,
       display: 'flex',
       alignItems: 'left',
       justifyContent: 'space-between',
      }}
     >
      <Box sx={{ gap: 2, display: 'flex', alignItems: 'center' }}>
       <IconButton
        variant='soft'
        color='primary'
        size='sm'
       >
        <BadgeRoundedIcon />
       </IconButton>
       <Typography level='title-lg'>Company logo</Typography>
      </Box>
      <ColorSchemeToggle />
     </Box>
     <Box
      component='main'
      sx={{
       my: 'auto',
       py: 2,
       pb: 5,
       display: 'flex',
       flexDirection: 'column',
       gap: 2,
       width: 400,
       maxWidth: '100%',
       mx: 'auto',
       borderRadius: 'sm',
       '& form': {
        display: 'flex',
        flexDirection: 'column',
        gap: 2,
       },
       [`& .${formLabelClasses.asterisk}`]: {
        visibility: 'hidden',
       },
      }}
     >
      <Stack
       gap={4}
       sx={{ mb: 2 }}
      >
       <Stack gap={1}>
        <Typography
         component='h1'
         level='h3'
        >
         Sign in
        </Typography>
       </Stack>
      </Stack>
      <Divider
       sx={(theme) => ({
        [theme.getColorSchemeSelector('light')]: {
         color: { xs: '#FFF', md: 'text.tertiary' },
         '--Divider-lineColor': {
          xs: '#FFF',
          md: 'var(--joy-palette-divider)',
         },
        },
       })}
      ></Divider>
      <Stack
       gap={4}
       sx={{ mt: 2 }}
      >
       <form onSubmit={handleSubmit(onSubmit)}>
        <FormControl required>
         <FormLabel>Email</FormLabel>
         <Input
          type='email'
          {...register('email')}
         />
        </FormControl>
        <FormControl required>
         <FormLabel>Password</FormLabel>
         <Input
          type='password'
          {...register('password')}
         />
        </FormControl>
        <Stack
         gap={4}
         sx={{ mt: 2 }}
        >
         <Box
          sx={{
           display: 'flex',
           justifyContent: 'space-between',
           alignItems: 'center',
          }}
         >
          <Controller
           name='persistent'
           control={control}
           render={({ field }) => (
            <Checkbox
             size='sm'
             label='Remember me'
             checked={field.value}
             onChange={field.onChange}
            />
           )}
          />
          <Link
           level='title-sm'
           href='#replace-with-a-link'
          >
           Forgot your password?
          </Link>
         </Box>
         <Button
          type='submit'
          fullWidth
          loading={loading}
         >
          Sign in
         </Button>
        </Stack>
       </form>
      </Stack>
     </Box>
     <Box
      component='footer'
      sx={{ py: 3 }}
     >
      <Typography
       level='body-xs'
       textAlign='center'
      >
       © Your company {new Date().getFullYear()}
      </Typography>
     </Box>
    </Box>
   </Box>
   <Box
    sx={(theme) => ({
     height: '100%',
     position: 'fixed',
     right: 0,
     top: 0,
     bottom: 0,
     left: 'clamp(0px, (100vw - var(--Collapsed-breakpoint)) * 999, 100vw - var(--Cover-width))',
     transition: 'background-image var(--Transition-duration), left var(--Transition-duration) !important',
     transitionDelay: 'calc(var(--Transition-duration) + 0.1s)',
     backgroundColor: 'background.level1',
     backgroundSize: 'cover',
     backgroundPosition: 'center',
     backgroundRepeat: 'no-repeat',
     backgroundImage: 'url(https://images.unsplash.com/photo-1527181152855-fc03fc7949c8?auto=format&w=1000&dpr=2)',
     [theme.getColorSchemeSelector('dark')]: {
      backgroundImage: 'url(https://images.unsplash.com/photo-1572072393749-3ca9c8ea0831?auto=format&w=1000&dpr=2)',
     },
    })}
   />
  </CssVarsProvider>
 )
}
