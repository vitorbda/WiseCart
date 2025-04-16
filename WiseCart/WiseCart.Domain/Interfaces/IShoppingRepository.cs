using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IShoppingRepository : IRepository<Shopping>
    {
        Task<IEnumerable<Shopping>> GetShoppingByUserIdAsync(Guid userId);
        Task<Shopping> SetDateEndAsync(Guid shoppingId, DateTime dateEnd);
        Task<Shopping> GetShoppingByIdAsync(Guid id);
    }
}
