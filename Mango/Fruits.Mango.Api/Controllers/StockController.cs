using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fruits.Common.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Mango.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // All methods use GET so that we can easily call them from a web browser.

        [HttpGet]
        public ActionResult<int> GetStock()
        {
            return _stockService.GetStock();
        }

        [HttpGet("buy/{count}")]
        public ActionResult Buy(int count)
        {
            _stockService.Buy(count);
            return Ok();
        }

        [HttpGet("sell/{count}")]
        public ActionResult Sell(int count)
        {
            _stockService.Sell(count);
            return Ok();
        }
    }
}
