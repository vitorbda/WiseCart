using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        
        [HttpPost("CreatePurchase")]
        public async Task<ActionResult<PurchaseDTO>> CreatePurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                var purchase = await _purchaseService.CreatePurchaseAsync(purchaseDTO);
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        [HttpGet("GetByShoppingId/{shoppingId}")]
        public async Task<ActionResult<PurchaseDTO>> GetByShoppingId(Guid shoppingId)
        {
            try
            {
                var purchase = await _purchaseService.GetByShoppingIdAsync(shoppingId);
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("UpdatePurchase")]
        public async Task<ActionResult<PurchaseDTO>> UpdatePurchase(PurchaseDTO purchaseDTO)
        {
            try
            {
                var purchaseUpdated = await _purchaseService.UpdateAsync(purchaseDTO);
                return Ok(purchaseUpdated);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("DeletePurchase/{id}")]
        public async Task<ActionResult<PurchaseDTO>> DeletePurchase(Guid id)
        {
            try
            {
                var purchaseDeleted = await _purchaseService.DeleteAsync(id);
                return Ok(purchaseDeleted);
            }
            catch
            {
                throw;
            }
        }
    }
}
