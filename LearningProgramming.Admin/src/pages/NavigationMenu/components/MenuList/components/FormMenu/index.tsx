import { Button, FormControl, FormHelperText, FormLabel, Input, Modal, ModalClose, Stack, Typography } from '@mui/joy'
import Sheet from '@mui/joy/Sheet'
import NavigationMenuApi from 'api/navigationMenuApi'
import { fetchNavigationMenus } from 'app/slices/navigationMenuSlice'
import { useAppDispatch } from 'app/store'
import { NavigationMenu } from 'models/NavigationMenu'
import { useEffect, useState } from 'react'
import { useForm } from 'react-hook-form'
import { toast } from 'react-toastify'

interface FormMenuProps {
 open: boolean
 setOpen: (open: boolean) => void
 menu: NavigationMenu | undefined
}

const FormMenu = ({ open, setOpen, menu }: FormMenuProps) => {
 const dispatch = useAppDispatch()
 const [loading, setLoading] = useState(false)
 const {
  register,
  handleSubmit,
  setValue,
  reset,
  formState: { errors },
 } = useForm()

 useEffect(() => {
  if (!menu || menu.parentId) {
   reset({ name: '', url: '', icon: '', position: 1 })
   return
  }
  setValue('name', menu.name)
  setValue('url', menu.url)
  setValue('icon', menu.icon)
  setValue('position', menu.position)
 }, [setValue, reset, menu])

 const onSubmit = (data: any) => {
  setLoading(true)
  if (!menu || menu.parentId)
   NavigationMenuApi.createNavigationMenu({ ...data, parentId: menu?.parentId })
    .then(() => {
     toast.success('Create successfully')
     dispatch(fetchNavigationMenus())
    })
    .catch(() => {})
    .finally(() => {
     setOpen(false)
     setLoading(false)
    })
  else
   NavigationMenuApi.updateNavigationMenu({ ...data, id: menu.id })
    .then(() => {
     toast.success('Update successfully')
     dispatch(fetchNavigationMenus())
    })
    .catch(() => {})
    .finally(() => {
     setOpen(false)
     setLoading(false)
    })
 }

 return (
  <Modal
   aria-labelledby='modal-title'
   aria-describedby='modal-desc'
   open={open}
   onClose={() => setOpen(false)}
   sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
   hideBackdrop={true}
  >
   <Sheet
    variant='outlined'
    sx={{
     maxWidth: 500,
     minWidth: 400,
     borderRadius: 'md',
     p: 3,
     boxShadow: 'lg',
    }}
   >
    <ModalClose
     variant='plain'
     sx={{ m: 1 }}
    />
    <Typography
     component='h2'
     id='modal-title'
     level='h4'
     textColor='inherit'
     fontWeight='lg'
     mb={1}
    >
     {!menu || menu.parentId ? 'Create' : 'Update'} navigation menu
    </Typography>
    <Stack
     sx={{
      mt: 2,
     }}
    >
     <form
      style={{
       display: 'flex',
       flexDirection: 'column',
       gap: 6,
      }}
      onSubmit={handleSubmit(onSubmit)}
     >
      <FormControl error={!!errors.name}>
       <FormLabel>Name</FormLabel>
       <Input
        type='text'
        {...register('name', { required: true })}
       />
       <FormHelperText>{errors.name ? 'Name is required' : ''}</FormHelperText>
      </FormControl>
      <FormControl error={!!errors.url}>
       <FormLabel>Url</FormLabel>
       <Input
        type='text'
        {...register('url', { required: true })}
       />
       <FormHelperText>{errors.url ? 'Url is required' : ''}</FormHelperText>
      </FormControl>
      <FormControl>
       <FormLabel>Icon</FormLabel>
       <Input
        type='text'
        {...register('icon')}
       />
      </FormControl>
      <FormControl error={!!errors.position}>
       <FormLabel>Position</FormLabel>
       <Input
        type='number'
        {...register('position', { required: true, min: 1 })}
       />
       <FormHelperText>
        {errors.position?.type === 'required' ? 'Position is required' : ''}
        {errors.position?.type === 'min' ? 'Position must be greater than 0' : ''}
       </FormHelperText>
      </FormControl>
      <FormControl>
       <Button
        type='submit'
        loading={loading}
       >
        Submit
       </Button>
      </FormControl>
     </form>
    </Stack>
   </Sheet>
  </Modal>
 )
}

export default FormMenu
