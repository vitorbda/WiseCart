using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Application.Services
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UnitOfMeasureService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private UnitOfMeasureDTO GetDto(UnitOfMeasure uom) => _mapper.Map<UnitOfMeasureDTO>(uom);
        private IEnumerable<UnitOfMeasureDTO> GetDto(IEnumerable<UnitOfMeasure> uom) => _mapper.Map<IEnumerable<UnitOfMeasureDTO>>(uom);

        public async Task<IEnumerable<UnitOfMeasureDTO>> GetAllAsync()
        {
            return GetDto(await _uow.UnitOfMeasureRepository.GetAllAsync());
        }
    }
}
