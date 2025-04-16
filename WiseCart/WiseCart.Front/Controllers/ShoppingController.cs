using Microsoft.AspNetCore.Mvc;
using WiseCart.Front.Models.InputModel;
using WiseCart.Front.Models.ViewModel;
using WiseCart.Front.Services.Interfaces;

namespace WiseCart.Front.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IShoppingService _shoppingService;
        private readonly IProductService _productService;

        public ShoppingController(IShoppingService shoppingService, IProductService productService)
        {
            _shoppingService = shoppingService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var shoppings = await _shoppingService.GetShoppingsByUserId(Guid.Parse("CEE20780-4E7F-47A4-A9A2-38B4AF10EC99"));

            return View(shoppings.OrderByDescending(s => s.DateStart));
        }

        public async Task<IActionResult> Section(Guid userId)
        {
            var model = new ShoppingInputModel
            {
                UserId = userId,
                Markets = await _shoppingService.GetAllMarkets()
            };

            return PartialView("~/Views/Shared/Shopping/_ModalStartShopping.cshtml", model);
        }

        public async Task<IActionResult> CreateShopping(ShoppingInputModel model)
        {
            var newShopping = await _shoppingService.CreateShopping(model);

            return RedirectToAction("Details", new { id = newShopping.Id });
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var shopping = await _shoppingService.GetById(id);
            shopping.Purchases = shopping.Purchases.OrderByDescending(p => p.Id);
            return View(shopping);
        }

        public IActionResult GetFormProduct(ProductViewModel? model)
        {
            var retorno = model ?? new ProductViewModel();

            return PartialView("_FormProduct", retorno);
        }

        public IActionResult GetFormPurchase()
        {
            var model = new PurchaseViewModel();
            return PartialView("~/Views/Shared/Shopping/_PurchaseInputForm.cshtml", model);
        }

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> CreateProduct(string codeBar)
        {
            var emptyModel = new ProductViewModel { Code = codeBar };

            if (string.IsNullOrEmpty(codeBar))
                return emptyModel;

            var newProduct = await _productService.CreateProductAsync(codeBar);

            return Ok(newProduct ?? emptyModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> CreateProduct(ProductInputModel model)
        {
            var newProduct = await _productService.CreateProductAsync(model);

            return Ok(newProduct);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase(PurchaseInputModel model)
        {
            var newPurchase = await _shoppingService.CreatePurchase(model);
            newPurchase._shoppingIsActive = true;

            return PartialView("~/Views/Shared/Shopping/_PurchaseViewCard.cshtml", newPurchase);
        }

        public async Task<ActionResult<IEnumerable<UnitOFMeasureViewModel>>> GetAllUOM()
        {
            var uoms = await _productService.GetAllUOMAsync();
            return Ok(uoms);
        }

        public async Task<IActionResult> UpdateEndDate(int shoppingId, DateTime dateEnd)
        {
            _ = await _shoppingService.UpdateEndDate(shoppingId, dateEnd);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePurchase(PurchaseInputModel model)
        {
            _ = await _shoppingService.UpdatePurchase(model);
            return Ok();
        }
    }
}
