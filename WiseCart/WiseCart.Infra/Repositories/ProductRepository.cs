using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<Product> GetProductByCodeBarAsync(string codeBar)
        {
            return await _context.Product
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Code == codeBar);
        }
    }
}
