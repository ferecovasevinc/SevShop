using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.Property(f => f.Name).IsRequired();

        builder.HasOne(f => f.AppUser)
               .WithMany(u => u.Favorites)
               .HasForeignKey(f => f.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(f => f.Product)
               .WithMany(p => p.Favorites)
               .HasForeignKey(f => f.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
