using Binance.Net.Enums;

namespace LearningProgramming.Application.Models.Binance
{
    public class OrderRequest
    {
        public string Symbol { get; set; }
        public OrderSide OrderSide { get; set; }
        public SpotOrderType SpotOrderType { get; set; }
        public decimal Quantity { get; set; }
    }
}
