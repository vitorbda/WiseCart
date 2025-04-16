using System.Text.Json;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Entities.ExternalProductApi;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Infra.Repositories
{
    public class ExternalProductApiRepository : IExternalProductApiRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string Uri = "https://world.openfoodfacts.net/api/v2/product/";
        private readonly JsonSerializerOptions _options;

        public ExternalProductApiRepository(IHttpClientFactory factory)
        {
            _clientFactory = factory;
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<Product> GetProductByCodeAsync(string codeBar)
        {
            var client = _clientFactory.CreateClient("CDBApi");
            var url = Uri + codeBar;

            using var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var productJson = JsonSerializer.Deserialize<ProductResponse>(content, _options);

            var product = new Product
            {
                Brands = productJson.Product.Brands,
                Code = productJson.Product.Code,
                Name = productJson.Product.Product_Name
            };

            return product;
        }
    }
}
