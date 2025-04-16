using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IUnitOfMeasureService
    {
        Task<IEnumerable<UnitOfMeasureDTO>> GetAllAsync();
    }
}
