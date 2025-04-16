using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private IShoppingRepository _shoppingRepository;
        private IPurchaseRepository _purchaseRepository;
        private IUnitOfMeasureRepository _unitOfMeasureRepository;
        private IMarketRepository _marketRepository;
        private IUserRepository _userRepository;
        private IRefreshTokenRepository _refreshTokenRepository;

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);

        public IShoppingRepository ShoppingRepository => _shoppingRepository ?? new ShoppingRepository(_context);

        public IPurchaseRepository PurchaseRepository => _purchaseRepository ?? new PurchaseRepository(_context);

        public IUnitOfMeasureRepository UnitOfMeasureRepository => _unitOfMeasureRepository ?? new UnitOfMeasureRepository(_context);

        public IMarketRepository MarketRepository => _marketRepository ?? new MarketRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IRefreshTokenRepository RefreshTokenRepository => _refreshTokenRepository ?? new RefreshTokenRepository(_context);

        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
