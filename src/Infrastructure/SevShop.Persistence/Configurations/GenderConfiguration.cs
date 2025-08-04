using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.Property(g => g.Name).IsRequired().HasMaxLength(30);
    }
}
