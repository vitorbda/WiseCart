using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(512);

            builder.Property(x => x.ExpiryDate)
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.Revoked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasIndex(x => x.Token)
                .IsClustered(false);
        }
    }
}
