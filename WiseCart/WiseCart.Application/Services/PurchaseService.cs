using AutoMapper;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;

namespace WiseCart.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PurchaseService(IUnitOfWork uow
            , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private Purchase GetEntity(PurchaseDTO purchaseDTO) => _mapper.Map<Purchase>(purchaseDTO);
        private PurchaseDTO GetDTO(Purchase purchase) => _mapper.Map<PurchaseDTO>(purchase);

        public async Task<PurchaseDTO> CreatePurchaseAsync(PurchaseDTO purchaseDTO)
        {
            var purchaseEntity = GetEntity(purchaseDTO);
            await _uow.PurchaseRepository.CreateAsync(purchaseEntity);
            await _uow.CommitAsync();

            return GetDTO(await _uow.PurchaseRepository.GetAsync(purchaseEntity.Id));
        }

        public async Task<PurchaseDTO> GetByShoppingIdAsync(Guid shoppingId)
        {
            var purchaseEntity = await _uow.PurchaseRepository.GetByShoppingId(shoppingId);

            return GetDTO(purchaseEntity);
        }

        public async Task<PurchaseDTO> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            var purchaseEntity = GetEntity(purchaseDTO);
            _uow.PurchaseRepository.Update(purchaseEntity);
            await _uow.CommitAsync();
            return GetDTO(purchaseEntity);

        }

        public async Task<PurchaseDTO> DeleteAsync(PurchaseDTO purchaseDTO)
        {
            var purchaseEntity = GetEntity(purchaseDTO);
            _uow.PurchaseRepository.DeleteAsync(purchaseEntity);
            await _uow.CommitAsync();
            return GetDTO(purchaseEntity);
        }

        public async Task<PurchaseDTO> GetByIdAsync(Guid id)
        {
            var purchaseEntity = await _uow.PurchaseRepository.GetAsync(id);
            return GetDTO(purchaseEntity);
        }

        public async Task<PurchaseDTO> DeleteAsync(Guid id)
        {
            var purchaseEntity = await _uow.PurchaseRepository.GetAsync(id);
            var purchaseDeleted = _uow.PurchaseRepository.DeleteAsync(purchaseEntity);
            await _uow.CommitAsync();
            return GetDTO(purchaseDeleted);
        }
    }
}
