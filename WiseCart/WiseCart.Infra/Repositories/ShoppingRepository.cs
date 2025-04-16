using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class ShoppingRepository : Repository<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(AppDbContext context) : base(context) { }
        
        private IQueryable<Shopping> GetEntity()
        {
            return _context.Shopping
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.Market)
                .Include(s => s.Purchases)
                    .ThenInclude(p => p.UnitOfMeasure)
                .Include(s => s.Purchases)
                    .ThenInclude(p => p.Product);
        }

        public async Task<IEnumerable<Shopping>> GetShoppingByUserIdAsync(Guid userId)
        {
            return await GetEntity().Where(s => s.UserId == userId).OrderByDescending(s => s.DateStart).ToListAsync();
        }

        public async Task<Shopping> SetDateEndAsync(Guid shoppingId, DateTime dateEnd)
        {
            var shopping = await base.GetAsync(shoppingId);
            shopping.DateEnd = dateEnd;
            return shopping;
        }

        public async Task<Shopping> GetShoppingByIdAsync(Guid id)
        {
            return await GetEntity().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
