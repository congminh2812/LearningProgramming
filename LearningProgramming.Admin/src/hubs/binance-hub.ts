import * as signalR from '@microsoft/signalr'
import LocalStorageService from 'services/LocalStorageService'
import StorageKeys from 'utils/storage-key'

interface BinanceHub {
 connection: signalR.HubConnection | undefined
 init: () => void
 onOrder: (callback: (order: any) => void) => void
 onPrices: (callback: (kline: any) => void) => void
 onStop: () => void
}

const binanceHub: BinanceHub = {
 connection: undefined,
 init: function () {
  const hubUrl = 'http://localhost:5229'

  this.connection = new signalR.HubConnectionBuilder()
   .withUrl(`${hubUrl}/hub/binanceHub`, {
    accessTokenFactory: () => LocalStorageService.get(StorageKeys.ACCESS_TOKEN) || '',
   })
   .withAutomaticReconnect()
   .build()

  this.connection
   .start()
   .then(() => {
    console.log('Connected to SignalR hub.')
   })
   .catch((error: any) => {
    console.error('Error connecting to SignalR hub:', error)
   })
 },
 onOrder: function (callback: (order: any) => void) {
  if (this.connection)
   this.connection.on('SendOrderToClient', (order: any) => {
    callback(order)
   })
 },
 onPrices: function (callback: (kline: any) => void) {
  if (this.connection)
   this.connection.on('SendPricesToClient', (kline: any) => {
    callback(kline)
   })
 },
 onStop: function () {
  if (this.connection)
   this.connection
    .stop()
    .then(() => {
     console.log('Disconnected to SignalR hub.')
    })
    .catch((error: any) => {
     console.error('Error disconnecting to SignalR hub:', error)
    })
 },
}

export default binanceHub
