using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class AIChatConfiguration : IEntityTypeConfiguration<AIChat>
{
    public void Configure(EntityTypeBuilder<AIChat> builder)
    {
        builder.Property(a => a.UserMessage).IsRequired().HasMaxLength(1000);
        builder.Property(a => a.AIResponse).IsRequired().HasMaxLength(2000);

        builder.HasOne(a => a.AppUser)
               .WithMany(u => u.AIChats)
               .HasForeignKey(a => a.AppUserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
