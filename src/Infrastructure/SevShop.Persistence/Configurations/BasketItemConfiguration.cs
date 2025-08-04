using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.Property(bi => bi.Quantity).IsRequired();
        builder.Property(bi => bi.Price).HasColumnType("decimal(18,2)");

        builder.HasIndex(bi => new { bi.BasketId, bi.ProductId }).IsUnique();
    }
}
