using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IExternalProductApiRepository
    {
        Task<Product> GetProductByCodeAsync(string codeBar);
    }
}
