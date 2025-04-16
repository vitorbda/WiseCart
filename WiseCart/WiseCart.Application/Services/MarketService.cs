using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Application.Services
{
    public class MarketService : IMarketService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MarketService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private IEnumerable<MarketDTO> GetDTO(IEnumerable<Market> markets) => _mapper.Map<IEnumerable<MarketDTO>>(markets);
        
        public async Task<IEnumerable<MarketDTO>> GetAllAsync()
        {
            var marketsEntity = await _uow.MarketRepository.GetAllAsync();

            return GetDTO(marketsEntity);
        }
    }
}
