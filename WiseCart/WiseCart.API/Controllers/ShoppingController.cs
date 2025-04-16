using Microsoft.AspNetCore.Mvc;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;
        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpGet("GetShoppingByUserId/{userId}")]
        public async Task<ActionResult<ShoppingDTO>> GetShoppingByUserId(Guid userId)
        {
            var shoppings = await _shoppingService.GetShoppingByUserIdAsync(userId);

            return Ok(shoppings);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ShoppingDTO>> GetById(Guid id)
        {
            var shopping = await _shoppingService.GetByIdAsync(id);

            return Ok(shopping);
        }

        [HttpPost("CreateShopping")]
        public async Task<ActionResult<ShoppingDTO>> CreateShopping(ShoppingDTO shoppingDTO)
        {
            try
            {
                var shopping = await _shoppingService.CreateShoppingAsync(shoppingDTO);
                return Ok(shopping);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("UpdateDateEnd")]
        public async Task<ActionResult<ShoppingDTO>> UpdateDateEnd(Guid shoppingId, DateTime dateEnd)
        {
            try
            {
                var shoppingDTO = await _shoppingService.UpdateDateEndAsync(shoppingId, dateEnd);

                return shoppingDTO;
            }
            catch
            {
                throw;
            }
        }
    }
}
