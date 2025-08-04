using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Configurations;

public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.Property(c => c.Message).IsRequired().HasMaxLength(1000);

        builder.HasOne(c => c.Sender)
               .WithMany(u => u.SentMessages)
               .HasForeignKey(c => c.SenderId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Receiver)
               .WithMany(u => u.ReceivedMessages)
               .HasForeignKey(c => c.ReceiverId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
