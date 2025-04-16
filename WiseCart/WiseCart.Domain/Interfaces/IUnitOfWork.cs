namespace WiseCart.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IShoppingRepository ShoppingRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        IUnitOfMeasureRepository UnitOfMeasureRepository { get; }
        IMarketRepository MarketRepository { get; }
        IUserRepository UserRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        Task CommitAsync();
    }
}
