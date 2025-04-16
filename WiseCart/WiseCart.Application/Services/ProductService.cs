using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IExternalProductApiRepository _externalProductApiRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProductService(IExternalProductApiRepository externalProductApiRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _externalProductApiRepository = externalProductApiRepository;            
            _mapper = mapper;
            _uow = unitOfWork;
        }

        private Product GetEntity(ProductDTO productDTO) => _mapper.Map<Product>(productDTO);
        private ProductDTO GetDTO(Product product) => _mapper.Map<ProductDTO>(product);
        private IEnumerable<ProductDTO> GetDTO(IEnumerable<Product> products) => _mapper.Map<IEnumerable<ProductDTO>>(products);


        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDTO)
        {
            var productDomain = GetEntity(productDTO);
            productDomain = await AddProductToDb(productDomain);
            await _uow.CommitAsync();

            return GetDTO(productDomain);
        }

        public async Task<ProductDTO> GetProductByCodeBarAsync(string codeBar)
        {
            var product = await _uow.ProductRepository.GetProductByCodeBarAsync(codeBar);

            if (product is null)
            {
                product = await _externalProductApiRepository.GetProductByCodeAsync(codeBar);
                product = await AddProductToDb(product);
                await _uow.CommitAsync();
                product = await GetProductFromDb(codeBar);
            }

            return GetDTO(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _uow.ProductRepository.GetAllAsync();

            return GetDTO(products);
        }

        private async Task<Product> AddProductToDb(Product product)
        {
            if (product is null) return null;

            return await _uow.ProductRepository.CreateAsync(product);
        }

        private async Task<Product> GetProductFromDb(string codeBar)
        {
            return await _uow.ProductRepository.GetProductByCodeBarAsync(codeBar);
        }
    }
}
