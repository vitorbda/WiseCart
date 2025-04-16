using WiseCart.Front.Models.InputModel;
using WiseCart.Front.Models.ViewModel;

namespace WiseCart.Front.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> CreateProductAsync(string codeBar);
        Task<ProductViewModel> CreateProductAsync(ProductInputModel model);
        Task<IEnumerable<UnitOFMeasureViewModel>> GetAllUOMAsync();
    }
}
