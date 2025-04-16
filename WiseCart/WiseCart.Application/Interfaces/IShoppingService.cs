using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IShoppingService
    {
        Task<ShoppingDTO> CreateShoppingAsync(ShoppingDTO shoppingDTO);
        Task<IEnumerable<ShoppingDTO>> GetShoppingByUserIdAsync(Guid userId);
        Task<ShoppingDTO> UpdateDateEndAsync(Guid shoppingId, DateTime dateEnd);
        Task<ShoppingDTO> GetByIdAsync(Guid id);
    }
}
