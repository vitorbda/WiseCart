using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context) { }

        private IQueryable<Purchase> GetPurchase()
        {
            return _context.Purchase
                .AsNoTracking()
                .Include(p => p.UnitOfMeasure)
                .Include(p => p.Product)
                .Include(p => p.Shopping);
        }

        public override async Task<Purchase> GetAsync(Guid id)
        {
            return await GetPurchase().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Purchase> GetByProductIdAsync(Guid productId)
        {
            return await GetPurchase().FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Purchase> GetByShoppingId(Guid shoppingId)
        {
            return await GetPurchase().FirstOrDefaultAsync(p => p.ShoppingId == shoppingId);
        }
    }
}
