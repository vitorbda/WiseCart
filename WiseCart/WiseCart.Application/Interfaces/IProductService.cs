using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByCodeBarAsync(string codeBar);
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> CreateProductAsync(ProductDTO productDTO);
    }
}
