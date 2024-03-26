using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Models.Binance;

namespace LearningProgramming.Application.Contracts.Binance
{
    public interface IBinanceService
    {
        Task<BinancePlacedOrder> Order(OrderRequest request);
        Task<List<BinanceOrder>> GetAllOrders(string symbol, int limit);
        Task<BinanceAccountInfo> GetAccountInformation();
        Task<List<IBinanceKline>> GetKlines(string symbol, KlineInterval klineInterval, int limit);
    }
}
