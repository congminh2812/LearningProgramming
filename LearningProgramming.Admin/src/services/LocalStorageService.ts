export default class LocalStorageService {
 // Method to get data from local storage
 static get(key: string): string | null {
  try {
   const value = localStorage.getItem(key)
   return value
  } catch (error) {
   console.error('Error getting data from local storage:', error)
   return null
  }
 }

 // Method to save data to local storage
 static set(key: string, value: string): void {
  try {
   localStorage.setItem(key, value)
  } catch (error) {
   console.error('Error saving data to local storage:', error)
  }
 }

 // Method to remove data from local storage
 static remove(key: string): void {
  try {
   localStorage.removeItem(key)
  } catch (error) {
   console.error('Error removing data from local storage:', error)
  }
 }
}
