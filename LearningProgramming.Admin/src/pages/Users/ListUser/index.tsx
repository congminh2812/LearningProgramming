/* eslint-disable jsx-a11y/anchor-is-valid */
import Box from '@mui/joy/Box'
import Button from '@mui/joy/Button'
import Divider from '@mui/joy/Divider'
import Dropdown from '@mui/joy/Dropdown'
import FormControl from '@mui/joy/FormControl'
import FormLabel from '@mui/joy/FormLabel'
import IconButton from '@mui/joy/IconButton'
import Input from '@mui/joy/Input'
import Menu from '@mui/joy/Menu'
import MenuButton from '@mui/joy/MenuButton'
import MenuItem from '@mui/joy/MenuItem'
import Sheet from '@mui/joy/Sheet'
import Table from '@mui/joy/Table'
import * as React from 'react'

import { AddCircleRounded } from '@mui/icons-material'
import MoreHorizRoundedIcon from '@mui/icons-material/MoreHorizRounded'
import SearchIcon from '@mui/icons-material/Search'

function RowMenu() {
 return (
  <Dropdown>
   <MenuButton
    slots={{ root: IconButton }}
    slotProps={{ root: { variant: 'plain', color: 'neutral', size: 'sm' } }}
   >
    <MoreHorizRoundedIcon />
   </MenuButton>
   <Menu
    size='sm'
    sx={{ minWidth: 140 }}
   >
    <MenuItem>Edit</MenuItem>
    <Divider />
    <MenuItem color='danger'>Delete</MenuItem>
   </Menu>
  </Dropdown>
 )
}

export default function ListUserPage() {
 return (
  <React.Fragment>
   <Box
    className='SearchAndFilters-tabletUp'
    sx={{
     borderRadius: 'sm',
     py: 2,
     display: { sm: 'flex' },
     alignItems: 'end',
     flexWrap: 'wrap',
     gap: 1.5,
     '& > *': {
      minWidth: { xs: '120px', md: '160px' },
     },
    }}
   >
    <FormControl
     sx={{ flex: 1 }}
     size='sm'
    >
     <FormLabel>Search for name</FormLabel>
     <Input
      size='sm'
      placeholder='Search'
      startDecorator={<SearchIcon />}
     />
    </FormControl>
    <Button
     type='button'
     sx={{ minWidth: '60px !important', minHeight: '30px' }}
    >
     <AddCircleRounded />
    </Button>
   </Box>
   <Sheet
    className='OrderTableContainer'
    variant='outlined'
    sx={{
     display: { xs: 'none', sm: 'initial' },
     width: '100%',
     borderRadius: 'sm',
     flexShrink: 1,
     overflow: 'auto',
     minHeight: 0,
    }}
   >
    <Table
     aria-labelledby='tableTitle'
     stickyHeader
     hoverRow
     sx={{
      '--TableCell-headBackground': 'var(--joy-palette-background-level1)',
      '--Table-headerUnderlineThickness': '1px',
      '--TableRow-hoverBackground': 'var(--joy-palette-background-level1)',
      '--TableCell-paddingY': '4px',
      '--TableCell-paddingX': '8px',
     }}
    >
     <thead>
      <tr>
       <th style={{ width: 240, padding: '12px 6px' }}>Email</th>
       <th style={{ width: 140, padding: '12px 6px' }}>Created Date</th>
       <th style={{ width: 140, padding: '12px 6px' }}>Role</th>
       <th style={{ width: 60, padding: '12px 6px' }}> </th>
      </tr>
     </thead>
     <tbody>
      <tr>
       <td>Test@gmail.com</td>
       <td>03/04/2024</td>
       <td>Admin</td>
       <td>
        <RowMenu />
       </td>
      </tr>
     </tbody>
    </Table>
   </Sheet>
  </React.Fragment>
 )
}
