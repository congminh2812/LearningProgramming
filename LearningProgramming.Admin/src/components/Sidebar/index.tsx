import BrightnessAutoRoundedIcon from '@mui/icons-material/BrightnessAutoRounded'
import DashboardRoundedIcon from '@mui/icons-material/DashboardRounded'
import GroupRoundedIcon from '@mui/icons-material/GroupRounded'
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown'
import LogoutRoundedIcon from '@mui/icons-material/LogoutRounded'
import SettingsRoundedIcon from '@mui/icons-material/SettingsRounded'
import ListRoundedIcon from '@mui/icons-material/ListRounded'
import Avatar from '@mui/joy/Avatar'
import Box from '@mui/joy/Box'
import Divider from '@mui/joy/Divider'
import GlobalStyles from '@mui/joy/GlobalStyles'
import IconButton from '@mui/joy/IconButton'
import List from '@mui/joy/List'
import ListItem from '@mui/joy/ListItem'
import ListItemButton, { listItemButtonClasses } from '@mui/joy/ListItemButton'
import ListItemContent from '@mui/joy/ListItemContent'
import Sheet from '@mui/joy/Sheet'
import Typography from '@mui/joy/Typography'
import NavigationMenuApi from 'api/navigationMenuApi'

import { useAuth } from 'components/AuthProvider'
import ColorSchemeToggle from 'components/ColorSchemeToggle'
import { Dispatch, ReactNode, SetStateAction, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import LocalStorageService from 'services/LocalStorageService'
import { closeSidebar } from 'utils/sidebar'
import StorageKeys from 'utils/storage-key'
import { NavigationMenu } from 'models/NavigationMenu'

function Toggler({
 defaultExpanded = false,
 renderToggle,
 children,
}: {
 defaultExpanded?: boolean
 children: ReactNode
 renderToggle: (params: { open: boolean; setOpen: Dispatch<SetStateAction<boolean>> }) => ReactNode
}) {
 const [open, setOpen] = useState(defaultExpanded)

 return (
  <>
   {renderToggle({ open, setOpen })}
   <Box
    sx={{
     display: 'grid',
     gridTemplateRows: open ? '1fr' : '0fr',
     transition: '0.2s ease',
     '& > *': {
      overflow: 'hidden',
     },
    }}
   >
    {children}
   </Box>
  </>
 )
}

const IconMenu = (icon: string) => {
 switch (icon) {
  case 'dashboard':
   return <DashboardRoundedIcon />
  case 'user':
   return <GroupRoundedIcon />
  case 'navigation-menu':
   return <ListRoundedIcon />
  default:
   return <DashboardRoundedIcon />
 }
}

export default function Sidebar() {
 const [menus, setMenus] = useState<NavigationMenu[]>([])
 const auth = useAuth()
 const navigate = useNavigate()
 const email = LocalStorageService.get(StorageKeys.EMAIL)
 const name = LocalStorageService.get(StorageKeys.NAME)
 const pathname = window.location.pathname

 useEffect(() => {
  NavigationMenuApi.getNavigationMenusByUserId()
   .then((res) => {
    if (res) setMenus(res)
   })
   .catch(() => {})
 }, [])

 const handleLogout = () => {
  auth.logout()
  navigate('/login')
 }

 return (
  <Sheet
   className='Sidebar'
   sx={{
    position: { xs: 'fixed', md: 'sticky' },
    transform: {
     xs: 'translateX(calc(100% * (var(--SideNavigation-slideIn, 0) - 1)))',
     md: 'none',
    },
    transition: 'transform 0.4s, width 0.4s',
    zIndex: 10000,
    height: '100dvh',
    width: 'var(--Sidebar-width)',
    top: 0,
    p: 2,
    flexShrink: 0,
    display: 'flex',
    flexDirection: 'column',
    gap: 2,
    borderRight: '1px solid',
    borderColor: 'divider',
   }}
  >
   <GlobalStyles
    styles={(theme) => ({
     ':root': {
      '--Sidebar-width': '220px',
      [theme.breakpoints.up('lg')]: {
       '--Sidebar-width': '240px',
      },
     },
    })}
   />
   <Box
    className='Sidebar-overlay'
    sx={{
     position: 'fixed',
     zIndex: 9998,
     top: 0,
     left: 0,
     width: '100vw',
     height: '100vh',
     opacity: 'var(--SideNavigation-slideIn)',
     backgroundColor: 'var(--joy-palette-background-backdrop)',
     transition: 'opacity 0.4s',
     transform: {
      xs: 'translateX(calc(100% * (var(--SideNavigation-slideIn, 0) - 1) + var(--SideNavigation-slideIn, 0) * var(--Sidebar-width, 0px)))',
      lg: 'translateX(-100%)',
     },
    }}
    onClick={() => closeSidebar()}
   />
   <Box sx={{ display: 'flex', gap: 1, alignItems: 'center' }}>
    <IconButton
     variant='soft'
     color='primary'
     size='sm'
    >
     <BrightnessAutoRoundedIcon />
    </IconButton>
    <Typography level='title-lg'>CM Dev</Typography>
    <ColorSchemeToggle sx={{ ml: 'auto' }} />
   </Box>
   <Box
    sx={{
     minHeight: 0,
     overflow: 'hidden auto',
     flexGrow: 1,
     display: 'flex',
     flexDirection: 'column',
     [`& .${listItemButtonClasses.root}`]: {
      gap: 1.5,
     },
    }}
   >
    <List
     size='sm'
     sx={{
      gap: 1,
      '--List-nestedInsetStart': '30px',
      '--ListItem-radius': (theme) => theme.vars.radius.sm,
     }}
    >
     {menus.map((menu: NavigationMenu) => (
      <ListItem
       key={menu.id}
       nested={menu.children.length > 0}
      >
       {menu.children.length === 0 && (
        <ListItemButton
         selected={pathname === menu.url}
         onClick={() => navigate(menu.url)}
        >
         {IconMenu(menu.icon)}
         <ListItemContent>
          <Typography level='title-sm'>{menu.name}</Typography>
         </ListItemContent>
        </ListItemButton>
       )}

       {menu.children.length > 0 && (
        <Toggler
         renderToggle={({ open, setOpen }) => (
          <ListItemButton onClick={() => setOpen(!open)}>
           {IconMenu(menu.icon)}
           <ListItemContent>
            <Typography level='title-sm'>{menu.name}</Typography>
           </ListItemContent>
           <KeyboardArrowDownIcon sx={{ transform: open ? 'rotate(180deg)' : 'none' }} />
          </ListItemButton>
         )}
        >
         <List sx={{ gap: 0.5 }}>
          {menu.children.map((x: NavigationMenu) => (
           <ListItem
            key={x.id}
            sx={{ mt: 0.5 }}
           >
            <ListItemButton
             selected={pathname === x.url}
             onClick={() => navigate(x.url)}
            >
             {x.name}
            </ListItemButton>
           </ListItem>
          ))}
         </List>
        </Toggler>
       )}
      </ListItem>
     ))}
    </List>

    <List
     size='sm'
     sx={{
      mt: 'auto',
      flexGrow: 0,
      '--ListItem-radius': (theme) => theme.vars.radius.sm,
      '--List-gap': '8px',
      mb: 2,
     }}
    >
     <ListItem key={'settings'}>
      <ListItemButton>
       <SettingsRoundedIcon />
       Settings
      </ListItemButton>
     </ListItem>
    </List>
   </Box>
   <Divider />
   <Box sx={{ display: 'flex', gap: 1, alignItems: 'center' }}>
    <Avatar
     variant='outlined'
     size='sm'
     src='https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?auto=format&fit=crop&w=286'
    />
    <Box sx={{ minWidth: 0, flex: 1 }}>
     <Typography level='title-sm'>{name}</Typography>
     <Typography level='body-xs'>{email}</Typography>
    </Box>
    <IconButton
     size='sm'
     variant='plain'
     color='neutral'
     onClick={handleLogout}
    >
     <LogoutRoundedIcon />
    </IconButton>
   </Box>
  </Sheet>
 )
}
