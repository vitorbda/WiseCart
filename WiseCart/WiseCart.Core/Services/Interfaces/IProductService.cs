using WiseCart.Core.Models;

namespace WiseCart.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Get(string codeBar);
    }
}
