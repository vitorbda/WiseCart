using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<RefreshToken> GetByTokenAsync(string token);
        RefreshToken Revoke(RefreshToken refreshToken);
    }
}
