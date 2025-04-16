using WiseCart.Front.Models.InputModel;
using WiseCart.Front.Models.ViewModel;

namespace WiseCart.Front.Services.Interfaces
{
    public interface IShoppingService
    {
        Task<IEnumerable<ShoppingViewModel>> GetShoppingsByUserId(Guid userId);
        Task<ShoppingViewModel> GetById(Guid id);
        Task<ShoppingViewModel> CreateShopping(ShoppingInputModel model);
        Task<PurchaseViewModel> CreatePurchase(PurchaseInputModel model);
        Task<IEnumerable<MarketViewModel>> GetAllMarkets();
        Task<ShoppingViewModel> UpdateEndDate(int shoppingId, DateTime dateEnd);
        Task<PurchaseViewModel> UpdatePurchase(PurchaseInputModel model);
    }
}
