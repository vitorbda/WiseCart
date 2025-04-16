using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.RefreshToken.AsNoTracking().FirstOrDefaultAsync(rt => rt.Token == token);
        }

        public RefreshToken Revoke(RefreshToken refreshToken)
        {
            refreshToken.Revoked = false;
            base.Update(refreshToken);
            return refreshToken;
        }
    }
}
