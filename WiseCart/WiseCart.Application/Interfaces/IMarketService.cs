using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IMarketService
    {
        Task<IEnumerable<MarketDTO>> GetAllAsync();
    }
}
