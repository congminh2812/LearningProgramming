using Binance.Net.Enums;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;
using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Contracts.Binance;
using LearningProgramming.Application.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Milad.Trading.TechnicalAnalysis.Indicators;

namespace LearningProgramming.Application.Workers
{
    public class TradeWorker(ILogger<TradeWorker> logger, IBinanceSocketClient binanceSocketClient, IHubContext<BinanceHub, IBinanceHubFunctions> binanceHubContext) : BackgroundService
    {
        private readonly IBinanceSocketClientSpotApiExchangeData _binanceSocketClientSpotApiExchangeData = binanceSocketClient.SpotApi.ExchangeData;
        private readonly IBinanceSocketClientSpotApiTrading _binanceSocketClientSpotApiTrading = binanceSocketClient.SpotApi.Trading;
        private readonly IBinanceSocketClientSpotApiAccount _binanceSocketClientSpotApiAccount = binanceSocketClient.SpotApi.Account;

        private const int ROUND = 6;
        private const int EVERY_TIME_BUY_USDT = 20;
        private const int KLINE_LIMIT = 55;
        private const KlineInterval KLINE_INTERVAL = KlineInterval.FiveMinutes;
        private const string ASSET = "BOME";
        private const string QUOTE_ASSET = "USDT";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Trade Worker started.");

            var streamKlines = await _binanceSocketClientSpotApiExchangeData.GetKlinesAsync($"{ASSET}{QUOTE_ASSET}", KLINE_INTERVAL, limit: KLINE_LIMIT);
            var klines = streamKlines.Data.Result.ToList();

            await _binanceSocketClientSpotApiExchangeData.SubscribeToKlineUpdatesAsync($"{ASSET}{QUOTE_ASSET}", KLINE_INTERVAL, (response) =>
            {
                var data = response.Data.Data;
                //SendPricesToClient(new BinanceSpotKline { ClosePrice = data.ClosePrice }).ConfigureAwait(false);

                //if (_buyPriceLatest > 0 && (data.ClosePrice > (_buyPriceLatest + _buyPriceLatest * (decimal)0.01)))
                //    Sell().ConfigureAwait(true);

                IList<double> listPrice = klines.Select(x => (double)Math.Round(x.ClosePrice, ROUND)).ToList();
                var listEMA50 = listPrice.ExponentialMovingAverages(x => x, 50, 5).Select(x => Math.Round(x, ROUND)).ToList();
                ExecuteStrategy(listEMA50.Last(), (double)klines[^2].OpenPrice, (double)klines[^2].ClosePrice, (double)data.ClosePrice);

                var last = klines.Last();

                if (data.OpenTime != last.OpenTime)
                {
                    klines.RemoveAt(0);
                    klines.Add(new BinanceSpotKline { ClosePrice = data.ClosePrice, OpenTime = data.OpenTime });
                    //CalSMA(klines).ConfigureAwait(true);
                }
                else
                {
                    var kline = klines.Find(x => x.OpenTime == data.OpenTime);
                    kline.ClosePrice = data.ClosePrice;
                }

            }, stoppingToken);

            if (stoppingToken.IsCancellationRequested)
                logger.LogInformation("Trade Worker stopped.");
        }

        private async Task CalSMA(List<BinanceSpotKline> data)
        {
            IList<double> listPrice = data.Select(x => (double)Math.Round(x.ClosePrice, ROUND)).ToList();
            var listSMA13 = listPrice.SimpleMovingAverages(x => x, 13).Select(x => Math.Round(x, ROUND)).ToList();
            var listSMA34 = listPrice.SimpleMovingAverages(x => x, 34).Select(x => Math.Round(x, ROUND)).ToList();

            var sma13NextLast = Math.Round(listSMA13[^3], ROUND);
            var sma34NextLast = Math.Round(listSMA34[^3], ROUND);

            var sma13Last = Math.Round(listSMA13[^2], ROUND);
            var sma34Last = Math.Round(listSMA34[^2], ROUND);

            if (sma13NextLast >= sma34NextLast && sma13Last < sma34Last)
                await Sell();

            if (sma13NextLast <= sma34NextLast && sma13Last > sma34Last)
                await Buy();
        }


        private async Task Buy()
        {
            var data = await _binanceSocketClientSpotApiTrading.PlaceOrderAsync($"{ASSET}{QUOTE_ASSET}", OrderSide.Buy, SpotOrderType.Market, quoteQuantity: EVERY_TIME_BUY_USDT);
            logger.LogInformation($"{DateTimeOffset.Now} - BUY");

            if (data.Data is not null)
            {
                await SendOrderToClient(data.Data.Result);
            }
        }

        private async Task Sell()
        {
            var accountInfo = await _binanceSocketClientSpotApiAccount.GetAccountInfoAsync();
            var balances = accountInfo.Data.Result.Balances;
            var balanceSHIB = balances.FirstOrDefault(x => x.Asset == ASSET);

            if (balanceSHIB is not null)
            {
                var data = await _binanceSocketClientSpotApiTrading.PlaceOrderAsync($"{ASSET}{QUOTE_ASSET}", OrderSide.Sell, SpotOrderType.Market, quantity: (int)balanceSHIB.Available);
                logger.LogInformation($"{DateTimeOffset.Now} - SELL: {balanceSHIB.Available}");

                if (data.Data is not null)
                {
                    await SendOrderToClient(data.Data.Result);
                }
            }
        }

        private async Task SendOrderToClient(BinancePlacedOrder order)
        {
            foreach (var connectionId in BinanceHub.ConnectedUsers.Values)
                await binanceHubContext.Clients.Client(connectionId).SendOrderToClient(order);
        }

        private async Task SendPricesToClient(BinanceSpotKline spotKline)
        {
            foreach (var connectionId in BinanceHub.ConnectedUsers.Values)
                await binanceHubContext.Clients.Client(connectionId).SendPricesToClient(spotKline);
        }

        // Tôi có giá mở cửa và đóng cửa của 1 cây nến gần nhất gọi là openPrice và closePrice

        // trường hợp 1: openPrice < EMA và closePrice < EMA
        // giá hiện tại dưới 2% của đường EMA -> buy lần 1
        // giá hiện tại dưới 1% của giá mua lần 1 -> buy lần 2
        // giá hiện tại dưới 1% của giá mua lần 2 -> buy lần 3
        // giá chạm đường EMA -> sell

        // trường hợp 2: openPrice > EMA và closePrice > EMA
        // giá hiện tại = EMA -> buy
        // giá hiện tại lên 2% so với buy lần 1 -> sell
        // ngược lại giá hiện tại nằm dưới EMA 1% -> sell


        public void ExecuteStrategy(double emaValue, double openPrice, double closePrice, double currentPrice)
        {
            // Calculate 1% and 2% of the EMA value
            double onePercentOfEma = emaValue * 0.01;
            double twoPercentOfEma = emaValue * 0.02;

            // Check if openPrice and closePrice are both below the EMA
            bool isBothPricesBelowEma = openPrice < emaValue && closePrice < emaValue;

            // Check if openPrice and closePrice are both above the EMA
            bool isBothPricesAboveEma = openPrice > emaValue && closePrice > emaValue;

            // Determine the strategy based on the conditions
            if (isBothPricesBelowEma)
            {
                // Check if the current price is below 2% of the EMA
                if (currentPrice < emaValue - twoPercentOfEma)
                {
                    // Execute buy logic
                    Console.WriteLine("Buy lần 1");
                }

                // Implement similar conditions for buy lần 2 and buy lần 3

                // Check if the current price touches the EMA
                if (currentPrice >= emaValue)
                {
                    // Execute sell logic
                    Console.WriteLine("Sell");
                }
            }
            else if (isBothPricesAboveEma)
            {
                // Check if the current price equals the EMA
                if (currentPrice <= emaValue)
                {
                    // Execute buy logic
                    Console.WriteLine("Buy");
                }

                // Check if the current price is above 2% of the EMA
                else if (currentPrice > emaValue + twoPercentOfEma)
                {
                    // Execute sell logic
                    Console.WriteLine("Sell");
                }

                // Implement condition for when the current price is below the EMA by 2%
                else if (currentPrice < emaValue * 0.98)
                {
                    // Execute sell logic
                    Console.WriteLine("Sell");
                }
            }
        }

    }
}
