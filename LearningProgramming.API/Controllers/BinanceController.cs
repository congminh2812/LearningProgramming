using Binance.Net.Enums;
using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Contracts.Binance;
using LearningProgramming.Application.Models.Binance;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class BinanceController(IBinanceService service) : BaseController
    {

        [HttpPost("order")]
        public async Task<ActionResult<List<BinanceOrder>>> Order(OrderRequest request)
        {
            var data = await service.Order(request);

            return Ok(data);
        }


        [HttpGet("getAllOrders")]
        public async Task<ActionResult<List<BinanceOrder>>> GetAllOrders(string symbol, int limit)
        {
            var data = await service.GetAllOrders(symbol, limit);

            return Ok(data);
        }

        [HttpGet("getAccountInformation")]
        public async Task<ActionResult<BinanceAccountInfo>> GetAccountInformation()
        {
            var data = await service.GetAccountInformation();

            return Ok(data);
        }

        [HttpGet("getKlines")]
        public async Task<ActionResult<BinanceAccountInfo>> GetKlines(string symbol, KlineInterval interval, int limit)
        {
            var data = await service.GetKlines(symbol, interval, limit);

            return Ok(data);
        }
    }
}
