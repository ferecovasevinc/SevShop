using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(x => x.Category)
            .WithMany(c => c.Products).
            HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(x => x.BrandId);

        builder.HasOne(x => x.Gender)
            .WithMany(g => g.Products)
            .HasForeignKey(x => x.GenderId);
    }
}
