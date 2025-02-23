using FNB.Assessment.Services.Api;
using FNB.Assessment.Services.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace FNB.Assessment.App.Controllers
{
    [ApiController]
    public class CoinStockController : ControllerBase
    {
        ICoinDispenserService _coinDispenserService;
        ILogger<CoinStockController> _logger;
        public CoinStockController(ICoinDispenserService coinDispenserService, ILogger<CoinStockController> logger)
        {
            _coinDispenserService = coinDispenserService;
            _logger = logger;
        }

        [HttpPost]
        [Route("~/api/change")]
        public string CalculateChange([FromBody] ChangeRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _coinDispenserService.GetChange(request.Amount, request.Denominations);
                _logger.LogInformation("Calculating change for amount {amount} {time:yyyy-MM-dd HH:mm:ss}", request.Amount, DateTime.Now);
                return result;
            }
            return "Please enter valid values to calculate change.";
        }
    }
}
