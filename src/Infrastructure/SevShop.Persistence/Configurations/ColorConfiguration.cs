using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Property(c => c.HexCode).IsRequired().HasMaxLength(7); 

        builder.Property(c => c.IsDark).IsRequired();
    }
}
