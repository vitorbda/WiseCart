using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<PurchaseDTO> CreatePurchaseAsync(PurchaseDTO purchaseDTO);
        Task<PurchaseDTO> GetByShoppingIdAsync(Guid shoppingId);
        Task<PurchaseDTO> GetByIdAsync(Guid id);
        Task<PurchaseDTO> UpdateAsync(PurchaseDTO purchaseDTO);
        Task<PurchaseDTO> DeleteAsync(PurchaseDTO purchaseDTO);
        Task<PurchaseDTO> DeleteAsync(Guid id);
    }
}
