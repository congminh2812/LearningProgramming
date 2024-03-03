import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import NavigationMenuApi from 'api/navigationMenuApi'
import { NavigationMenu } from 'models/NavigationMenu'

// Async action creator
export const fetchNavigationMenus = createAsyncThunk('fetchNavigationMenus', async (_, thunkAPI) => {
 try {
  const menus = await NavigationMenuApi.getNavigationMenus()
  return menus
 } catch (error: any) {
  return thunkAPI.rejectWithValue(error.message)
 }
})

interface NavigationMenuState {
 menus: NavigationMenu[]
 loading: boolean
 error: any
}

const initialState: NavigationMenuState = {
 menus: [],
 loading: false,
 error: null,
}

const navigationMenuSlice = createSlice({
 name: 'navigationMenu',
 initialState: initialState,
 reducers: {},
 extraReducers(builder) {
  builder.addCase(fetchNavigationMenus.pending, (state) => {
   state.loading = true
  })
  builder.addCase(fetchNavigationMenus.fulfilled, (state, action) => {
   state.loading = false
   state.menus = action.payload
  })
  builder.addCase(fetchNavigationMenus.rejected, (state) => {
   state.loading = false
  })
 },
})

const { reducer } = navigationMenuSlice

export default reducer
