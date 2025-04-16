using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<Purchase> GetByProductIdAsync(Guid productId);
        Task<Purchase> GetByShoppingId(Guid shoppingId);
    }
}
