using Microsoft.AspNetCore.Mvc;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IUnitOfMeasureService _uomService;

        public UnitOfMeasureController(IUnitOfMeasureService uomService)
        {
            _uomService = uomService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureDTO>>> GetAll()
        {
            try
            {
                var uom = await _uomService.GetAllAsync();
                return Ok(uom);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
