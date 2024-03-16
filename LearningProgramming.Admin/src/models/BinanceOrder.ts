import { BinanceSideEnum, BinanceStatusEnum, BinanceTypeEnum } from 'utils/enums/binance-enum'

export interface BinanceOrder {
 symbol: string
 clientOrderId: string
 price: number
 quantity: number
 status: BinanceStatusEnum
 type: BinanceTypeEnum
 side: BinanceSideEnum
 createTime: Date
}
