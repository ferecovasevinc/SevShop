using System.ComponentModel.DataAnnotations;

namespace SevShop.Domain.Entities;

public class AIChat : BaseEntity
{
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    [Required]
    public string UserMessage { get; set; }

    [Required]
    public string AIResponse { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
