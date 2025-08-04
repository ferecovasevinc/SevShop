using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.Property(b => b.BuyerId).IsRequired();
        builder.Property(b => b.CreatedDate).IsRequired();

        builder.HasMany(b => b.Items)
               .WithOne()
               .HasForeignKey(i => i.BasketId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
