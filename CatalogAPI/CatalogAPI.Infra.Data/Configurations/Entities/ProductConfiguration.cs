using CatalogAPI.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogAPI.Infra.Data.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasPrecision(10, 2);

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.Property(p => p.UrlImage)
                .HasMaxLength(250)
                .IsRequired(false);


            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
