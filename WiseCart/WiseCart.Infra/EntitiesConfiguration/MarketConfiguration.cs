using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class MarketConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Street)                
                .HasMaxLength(50);

            builder.Property(x => x.City)
                .HasMaxLength(30);

            builder.Property(x => x.State)
                .HasMaxLength(30);

            builder.Property(x => x.District)
                .HasMaxLength(30);
        }
    }
}
