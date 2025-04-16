using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Shopping> Shopping { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<MarketXUser> MarketXUser { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            SetAlterDate();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAlterDate();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetAlterDate()
        {
            var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified);

            foreach (var entry in entries)            
                if (entry.Entity is Entity entity)                
                    entity.AlterDate = DateTime.UtcNow;
        }
    }
}
