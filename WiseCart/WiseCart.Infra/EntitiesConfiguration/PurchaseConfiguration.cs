using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.UnitOfMeasureId)
                .IsRequired();

            builder.HasOne(p => p.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(p => p.UnitOfMeasureId)
                .IsRequired();

            builder.Property(p => p.ShoppingId)
                .IsRequired();

            builder.HasOne(p => p.Shopping)
                .WithMany(s => s.Purchases)
                .HasForeignKey(p => p.ShoppingId)
                .IsRequired();

            builder.HasIndex(p => p.ShoppingId)
                .IsClustered(false);
        }

    }
}
