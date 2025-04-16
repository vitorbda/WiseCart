using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("Get/{codeBar}")]
        public async Task<ActionResult<ProductDTO>> GetProductByCodeBar(string codeBar)
        {
            var product = await _service.GetProductByCodeBarAsync(codeBar);

            if (product == null)            
                return NotFound();
            
            return Ok(product);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _service.GetProductsAsync();
            
            if (products == null)            
                return NotFound();
            
            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            try
            {
                var product = await _service.CreateProductAsync(productDTO);

                if (product is null)
                    return BadRequest();

                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("teste")]
        public ActionResult<string> teste()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok(username);
        }
    }
}
