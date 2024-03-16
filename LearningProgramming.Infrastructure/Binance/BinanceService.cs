using Binance.Net.Interfaces.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;
using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Contracts.Binance;

namespace LearningProgramming.Infrastructure.Binance
{
    public class BinanceService(IBinanceRestClient binanceRestClient) : IBinanceService
    {
        private readonly IBinanceRestClientSpotApiTrading _binanceRestClientSpotApiTrading = binanceRestClient.SpotApi.Trading;

        public async Task<List<BinanceOrder>> GetAllOrders(string symbol, int limit)
        {
            var result = await _binanceRestClientSpotApiTrading.GetOrdersAsync(symbol);
            var data = result.Data.OrderByDescending(x => x.CreateTime).ToList();

            return data ?? [];
        }

        public async Task<BinanceAccountInfo> GetAccountInformation()
        {
            var result = await binanceRestClient.SpotApi.Account.GetAccountInfoAsync();
            BinanceAccountInfo data = result.Data;

            if (data is not null)
                data.Balances = data.Balances.Where(x => x.Available > 0).ToList();

            //IList<double> list = new List<double>() { 1,2,3,4};
            //list.SimpleMovingAverages(x => x, 13);

            return data ?? new BinanceAccountInfo();
        }
    }
}
