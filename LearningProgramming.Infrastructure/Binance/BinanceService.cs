using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;
using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Contracts.Binance;
using LearningProgramming.Application.Exceptions;
using LearningProgramming.Application.Models.Binance;
using Milad.Trading.TechnicalAnalysis.Indicators;

namespace LearningProgramming.Infrastructure.Binance
{
    public class BinanceService(IBinanceRestClient binanceRestClient) : IBinanceService
    {
        private readonly IBinanceRestClientSpotApiTrading _binanceRestClientSpotApiTrading = binanceRestClient.SpotApi.Trading;
        private readonly IBinanceRestClientSpotApiAccount _binanceRestClientSpotApiAccount = binanceRestClient.SpotApi.Account;
        private readonly IBinanceRestClientSpotApiExchangeData _binanceRestClientSpotApiExchangeData = binanceRestClient.SpotApi.ExchangeData;

        public async Task<BinancePlacedOrder> Order(OrderRequest request)
        {
            var result = await _binanceRestClientSpotApiTrading.PlaceOrderAsync(request.Symbol, request.OrderSide, request.SpotOrderType, request.Quantity);

            return result.Data;
        }

        public async Task<List<BinanceOrder>> GetAllOrders(string symbol, int limit)
        {
            var result = await _binanceRestClientSpotApiTrading.GetOrdersAsync(symbol, limit: limit);

            if (result.Data is null)
                throw new BadRequestException(result.Error?.Message);

            var data = result.Data.OrderByDescending(x => x.CreateTime).ToList();

            return data ?? [];
        }

        public async Task<BinanceAccountInfo> GetAccountInformation()
        {
            var result = await _binanceRestClientSpotApiAccount.GetAccountInfoAsync();
            BinanceAccountInfo data = result.Data;

            if (data is not null)
                data.Balances = data.Balances.Where(x => x.Available > 0).ToList();

            var test = await _binanceRestClientSpotApiAccount.GetDailySpotAccountSnapshotAsync();
            var test2 = test.Data;

            return data ?? new BinanceAccountInfo();
        }

        public async Task<List<IBinanceKline>> GetKlines(string symbol, KlineInterval klineInterval, int limit)
        {
            var result = await _binanceRestClientSpotApiExchangeData.GetKlinesAsync(symbol, klineInterval, limit: limit);

            if (result.Data is null)
                throw new BadRequestException(result.Error?.Message);

            IList<double> listPrice = result.Data.Select(x => (double)Math.Round(x.ClosePrice, 8)).ToList();
            var sma13 = Math.Round(listPrice.SimpleMovingAverages(x => x, 13).Last(), 8);
            var sma34 = Math.Round(listPrice.SimpleMovingAverages(x => x, 34).Last(), 8);

            return result.Data.ToList();
        }
    }
}
