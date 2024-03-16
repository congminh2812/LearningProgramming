using Binance.Net.Objects.Models.Spot;
using LearningProgramming.Application.Contracts.Binance;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class BinanceController(IBinanceService service) : BaseController
    {

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
    }
}
