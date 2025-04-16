using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Application.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShoppingService(IUnitOfWork uow
            , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private Shopping GetEntity(ShoppingDTO shoppingDTO) => _mapper.Map<Shopping>(shoppingDTO);
        private ShoppingDTO GetDTO(Shopping shopping) => _mapper.Map<ShoppingDTO>(shopping);
        private IEnumerable<ShoppingDTO> GetDTO(IEnumerable<Shopping> shopping) => _mapper.Map<IEnumerable<ShoppingDTO>>(shopping);

        public async Task<ShoppingDTO> CreateShoppingAsync(ShoppingDTO shoppingDTO)
        {
            var shoppingEntity = GetEntity(shoppingDTO);
            await _uow.ShoppingRepository.CreateAsync(shoppingEntity);
            await _uow.CommitAsync();

            return GetDTO(shoppingEntity);
        }

        public async Task<IEnumerable<ShoppingDTO>> GetShoppingByUserIdAsync(Guid userId)
        {
            var shoppingEntity = await _uow.ShoppingRepository.GetShoppingByUserIdAsync(userId);

            return GetDTO(shoppingEntity);
        }
        
        public async Task<ShoppingDTO> UpdateDateEndAsync(Guid shoppingId, DateTime dateEnd)
        {
            var shoppingEntity = await _uow.ShoppingRepository.SetDateEndAsync(shoppingId, dateEnd);
            await _uow.CommitAsync();

            return GetDTO(shoppingEntity);
        }

        public async Task<ShoppingDTO> GetByIdAsync(Guid id)
        {
            var shoppingEntity = await _uow.ShoppingRepository.GetShoppingByIdAsync(id);

            return GetDTO(shoppingEntity);
        }
    }
}
