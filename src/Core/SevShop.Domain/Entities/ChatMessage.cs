using System.ComponentModel.DataAnnotations;

namespace SevShop.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public Guid SenderId { get; set; }
    public AppUser Sender { get; set; }

    public Guid ReceiverId { get; set; }
    public AppUser Receiver { get; set; }
    public string Message { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;
}
