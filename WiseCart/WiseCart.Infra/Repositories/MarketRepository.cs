using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class MarketRepository : Repository<Market>, IMarketRepository
    {
        public MarketRepository(AppDbContext context) : base(context)
        {
        }
    }
}
