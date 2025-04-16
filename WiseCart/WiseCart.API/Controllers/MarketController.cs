using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MarketDTO>>> GetAll()
        {
            var markets = await _marketService.GetAllAsync();
            return Ok(markets);
        }
    }
}
