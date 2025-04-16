using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WiseCart.Domain.Entities;

namespace WiseCart.Infra.EntitiesConfiguration
{
    public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Abbreviation)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasData(
                new UnitOfMeasure { Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"), Name = "Unidade", Abbreviation = "un", AddDate = new DateTime(2025, 03, 26), IsActive = true },
                new UnitOfMeasure { Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174001"), Name = "Quilograma", Abbreviation = "kg", AddDate = new DateTime(2025, 03, 26), IsActive = true },
                new UnitOfMeasure { Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174002"), Name = "Grama", Abbreviation = "g", AddDate = new DateTime(2025, 03, 26), IsActive = true },
                new UnitOfMeasure { Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174003"), Name = "Litro", Abbreviation = "l", AddDate = new DateTime(2025, 03, 26), IsActive = true },
                new UnitOfMeasure { Id = Guid.Parse("123e4567-e89b-12d3-a456-426614174004"), Name = "Mililitro", Abbreviation = "ml", AddDate = new DateTime(2025, 03, 26), IsActive = true }
            );

        }
    }
}
