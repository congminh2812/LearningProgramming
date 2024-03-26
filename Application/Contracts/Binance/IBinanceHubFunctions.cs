using Binance.Net.Objects.Models.Spot;

namespace LearningProgramming.Application.Contracts.Binance
{
    public interface IBinanceHubFunctions
    {
        Task SendOrderToClient(BinancePlacedOrder order);
        Task SendPricesToClient(BinanceSpotKline spotKline);
    }
}
