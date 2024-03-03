import Box from '@mui/joy/Box'
import IconButton from '@mui/joy/IconButton'
import List from '@mui/joy/List'
import ListItem from '@mui/joy/ListItem'
import Typography from '@mui/joy/Typography'
import * as React from 'react'

import KeyboardArrowDown from '@mui/icons-material/KeyboardArrowDown'
import ReceiptLong from '@mui/icons-material/ReceiptLong'
import ListItemButton, { listItemButtonClasses } from '@mui/joy/ListItemButton'
import { NavigationMenu } from 'models/NavigationMenu'
import { AddCircleRounded, DeleteOutlineRounded, EditRounded } from '@mui/icons-material'
import FormMenu from './components/FormMenu'
import NavigationMenuApi from 'api/navigationMenuApi'
import { toast } from 'react-toastify'
import ConfirmDelete from 'components/ConfirmDelete'
import { useAppDispatch } from 'app/store'
import { fetchNavigationMenus } from 'app/slices/navigationMenuSlice'

interface MenuListProps {
 menus: NavigationMenu[]
}

export default function MenuList({ menus }: MenuListProps) {
 const dispatch = useAppDispatch()
 const [openForm, setOpenForm] = React.useState(false)
 const [openDelete, setOpenDelete] = React.useState(false)
 const [menusClone, setMenusClone] = React.useState<any[]>(menus)
 const [selectedMenu, setSelectedMenu] = React.useState<NavigationMenu | undefined>()

 React.useEffect(() => {
  setMenusClone(menus.map((x) => ({ ...x, isOpen: false })))
 }, [menus])

 const handleClickItem = (item: any) => {
  const dataClone = [
   ...menusClone.map((x) => {
    if (x.id === item.id) x.isOpen = !x.isOpen

    return x
   }),
  ]
  setMenusClone(dataClone)
 }

 const handleClickAdd = (item: NavigationMenu | undefined) => {
  setOpenForm(true)
  setSelectedMenu(item)
 }

 const handleClickDelete = (item: NavigationMenu | undefined) => {
  setOpenDelete(true)
  setSelectedMenu(item)
 }

 const handleClickConfirmDelete = () => {
  if (!selectedMenu) return
  setOpenDelete(false)
  NavigationMenuApi.deleteNavigationMenu(selectedMenu.id)
   .then(() => {
    toast.success('Delete successfully')
    dispatch(fetchNavigationMenus())
   })
   .catch()
 }

 const renderButtons = (item: any) => {
  return (
   <>
    <IconButton
     size='sm'
     sx={{ verticalAlign: 'middle' }}
     color='success'
     onClick={() => {
      handleClickAdd({ ...item, parentId: item.id })
     }}
    >
     <AddCircleRounded />
    </IconButton>
    <IconButton
     size='sm'
     sx={{ verticalAlign: 'middle' }}
     color='primary'
     onClick={() => {
      handleClickAdd({ ...item, parentId: undefined })
     }}
    >
     <EditRounded />
    </IconButton>
    <IconButton
     size='sm'
     sx={{ verticalAlign: 'middle' }}
     color='danger'
     onClick={() => {
      handleClickDelete(item)
     }}
    >
     <DeleteOutlineRounded />
    </IconButton>
   </>
  )
 }

 return (
  <Box
   sx={{
    width: '100%',
    pl: '24px',
   }}
  >
   <List
    size='sm'
    sx={(theme) => ({
     '--joy-palette-primary-plainColor': '#8a4baf',
     '--joy-palette-neutral-plainHoverBg': 'transparent',
     '--joy-palette-neutral-plainActiveBg': 'transparent',
     '--joy-palette-primary-plainHoverBg': 'transparent',
     '--joy-palette-primary-plainActiveBg': 'transparent',
     [theme.getColorSchemeSelector('dark')]: {
      '--joy-palette-text-secondary': '#635e69',
      '--joy-palette-primary-plainColor': '#d48cff',
     },

     '--List-insetStart': '32px',
     '--ListItem-paddingY': '0px',
     '--ListItem-paddingRight': '16px',
     '--ListItem-paddingLeft': '21px',
     '--ListItem-startActionWidth': '0px',
     '--ListItem-startActionTranslateX': '-50%',

     [`& .${listItemButtonClasses.root}`]: {
      borderLeftColor: 'divider',
     },
     [`& .${listItemButtonClasses.root}.${listItemButtonClasses.selected}`]: {
      borderLeftColor: 'currentColor',
     },
     '& [class*="startAction"]': {
      color: 'var(--joy-palette-text-tertiary)',
     },
    })}
   >
    <ListItem nested>
     <ListItem
      component='div'
      startAction={<ReceiptLong />}
     >
      <Typography
       level='body-xs'
       sx={{ textTransform: 'uppercase' }}
      >
       Navigation menus
      </Typography>
      <IconButton
       size='sm'
       color='success'
       onClick={() => {
        handleClickAdd(undefined)
       }}
      >
       <AddCircleRounded />
      </IconButton>
     </ListItem>
    </ListItem>

    {menusClone.map((menu) => (
     <ListItem
      key={menu.id}
      nested
      sx={{ my: 1 }}
      startAction={
       <IconButton
        variant='plain'
        size='sm'
        color='neutral'
        onClick={() => handleClickItem(menu)}
       >
        <KeyboardArrowDown sx={{ transform: menu.isOpen ? 'initial' : 'rotate(-90deg)' }} />
       </IconButton>
      }
     >
      <ListItem>
       <Typography
        level='inherit'
        sx={{
         fontWeight: menu.isOpen ? 'bold' : undefined,
         color: menu.isOpen ? 'text.primary' : 'inherit',
        }}
       >
        {menu.name}
        {menu.children.length > 0 && (
         <Typography
          component='span'
          level='body-xs'
         >
          {` (${menu.children.length})`}
         </Typography>
        )}
        {renderButtons(menu)}
       </Typography>
      </ListItem>

      {menu.isOpen && (
       <List sx={{ '--ListItem-paddingY': '8px' }}>
        {menu.children.map((c: any) => (
         <ListItem key={c.id}>
          <ListItemButton sx={{ gap: 0 }}>
           {c.name}
           {renderButtons(c)}
          </ListItemButton>
         </ListItem>
        ))}
       </List>
      )}
     </ListItem>
    ))}
   </List>

   <FormMenu
    open={openForm}
    setOpen={setOpenForm}
    menu={selectedMenu}
   />
   <ConfirmDelete
    open={openDelete}
    setOpen={setOpenDelete}
    onConfirm={handleClickConfirmDelete}
   />
  </Box>
 )
}
