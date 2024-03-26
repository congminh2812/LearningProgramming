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

        private const int ROUND = 8;
        private const int EVERY_TIME_BUY_USDT = 20;
        private const int KLINE_LIMIT = 40;
        private const KlineInterval KLINE_INTERVAL = KlineInterval.FiveMinutes;
        private const string ASSET = "BOME";
        private const string QUOTE_ASSET = "USDT";
        private decimal _buyPriceLatest = 0;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Trade Worker started.");

            var streamKlines = await _binanceSocketClientSpotApiExchangeData.GetKlinesAsync($"{ASSET}{QUOTE_ASSET}", KLINE_INTERVAL, limit: KLINE_LIMIT);
            var klines = streamKlines.Data.Result.ToList();

            await _binanceSocketClientSpotApiExchangeData.SubscribeToKlineUpdatesAsync($"{ASSET}{QUOTE_ASSET}", KLINE_INTERVAL, (response) =>
            {
                var data = response.Data.Data;
                SendPricesToClient(new BinanceSpotKline { ClosePrice = data.ClosePrice }).ConfigureAwait(false);

                //if (_buyPriceLatest > 0 && (data.ClosePrice > (_buyPriceLatest + _buyPriceLatest * (decimal)0.01)))
                //    Sell().ConfigureAwait(true);

                var last = klines.Last();

                if (data.OpenTime != last.OpenTime)
                {
                    klines.RemoveAt(0);
                    klines.Add(new BinanceSpotKline { ClosePrice = data.ClosePrice, OpenTime = data.OpenTime });
                    CalSMA(klines).ConfigureAwait(true);
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
                _buyPriceLatest = data.Data.Result.Price;
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
                    _buyPriceLatest = 0;
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
    }
}
