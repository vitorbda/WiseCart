using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class ShoppingConfiguration : IEntityTypeConfiguration<Shopping>
    {
        public void Configure(EntityTypeBuilder<Shopping> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.DateStart)
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(s => s.DateEnd)
                .HasColumnType("timestamptz");

            builder.Property(s => s.UserId)
                .IsRequired();
            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            builder.Property(s => s.MarketId)
                .IsRequired();
            builder.HasOne(s => s.Market)
                .WithMany()
                .HasForeignKey(s => s.MarketId);

            builder.HasIndex(s =>s.UserId)
                .IsClustered(false);
        }
    }
}
