using System.Text;
using System.Text.Json;
using WiseCart.Front.Models.InputModel;
using WiseCart.Front.Models.ViewModel;
using WiseCart.Front.Services.Interfaces;

namespace WiseCart.Front.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("Product/GetAll");

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<ProductViewModel>();

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(content, _options);

            return products;
        }

        public async Task<ProductViewModel> CreateProductAsync(string codeBar)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("Product/Get/" + codeBar);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<ProductViewModel>(content, _options);

            return product;
        }

        public async Task<IEnumerable<UnitOFMeasureViewModel>> GetAllUOMAsync()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("UnitOfMEasure/GetAll/");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<UnitOFMeasureViewModel>>(responseContent, _options);
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductInputModel model)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.PostAsync("Product/CreateProduct", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductViewModel>(responseContent, _options);
        }
    }
}
