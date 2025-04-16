using System.Text;
using System.Text.Json;
using WiseCart.Front.Models.InputModel;
using WiseCart.Front.Models.ViewModel;
using WiseCart.Front.Services.Interfaces;

namespace WiseCart.Front.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;

        public ShoppingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ShoppingViewModel>> GetShoppingsByUserId(Guid userId)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("Shopping/GetShoppingByUserId/" + userId);

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<ShoppingViewModel>();

            var content = await response.Content.ReadAsStringAsync();
            var shoppings = JsonSerializer.Deserialize<IEnumerable<ShoppingViewModel>>(content, _options);

            return shoppings;
        }

        public async Task<ShoppingViewModel> CreateShopping(ShoppingInputModel model)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.PostAsync("Shopping/CreateShopping", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ShoppingViewModel>(responseContent, _options);
        }

        public async Task<ShoppingViewModel> GetById(Guid id)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("Shopping/GetById/" + id);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ShoppingViewModel>(responseContent, _options);
        }

        public async Task<PurchaseViewModel> CreatePurchase(PurchaseInputModel model)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.PostAsync("Purchase/CreatePurchase", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PurchaseViewModel>(responseContent, _options);
        }

        public async Task<IEnumerable<MarketViewModel>> GetAllMarkets()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.GetAsync("Market/GetAll");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<MarketViewModel>>(responseContent, _options);
        }

        public async Task<ShoppingViewModel> UpdateEndDate(int shoppingId, DateTime dateEnd)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using var response = await client.PutAsync($"Shopping/UpdateDateEnd?shoppingId={shoppingId}&dateEnd={dateEnd}", null);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ShoppingViewModel>(responseContent, _options);
        }

        public async Task<PurchaseViewModel> UpdatePurchase(PurchaseInputModel model)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.PutAsync($"Purchase/UpdatePurchase", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PurchaseViewModel>(responseContent, _options);
        }
    }
}
