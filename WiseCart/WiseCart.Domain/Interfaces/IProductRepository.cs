using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByCodeBarAsync(string codeBar);
    }
}
