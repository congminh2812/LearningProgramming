using Binance.Net.Objects.Models.Spot;

namespace LearningProgramming.Application.Contracts.Binance
{
    public interface IBinanceService
    {
        Task<List<BinanceOrder>> GetAllOrders(string symbol, int limit);
        Task<BinanceAccountInfo> GetAccountInformation();
    }
}
