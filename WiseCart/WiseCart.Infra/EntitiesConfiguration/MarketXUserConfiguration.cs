using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class MarketXUserConfiguration : IEntityTypeConfiguration<MarketXUser>
    {
        public void Configure(EntityTypeBuilder<MarketXUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.MarketId)
                .IsRequired();
            builder.HasOne(x => x.Market)
                .WithMany()
                .HasForeignKey(x => x.MarketId);

            builder.Property(x => x.UserId)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasIndex(x => x.UserId)
                .IsClustered(false);
        }
    }
}
