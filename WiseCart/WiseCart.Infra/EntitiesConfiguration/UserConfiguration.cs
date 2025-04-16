using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(u => u.UserName)
                .IsClustered(false)
                .IsUnique();
        }
    }
}
