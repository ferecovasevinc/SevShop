using System.ComponentModel.DataAnnotations;

namespace SevShop.Domain.Entities;

public class ChatMessage : BaseEntity
{
    public string SenderId { get; set; }
    public AppUser Sender { get; set; }

    public string ReceiverId { get; set; }
    public AppUser Receiver { get; set; }
    public string Message { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public bool IsRead { get; set; } = false;
}
