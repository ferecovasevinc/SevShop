using Microsoft.AspNetCore.Identity;
using System.Net;

namespace SevShop.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public bool IsActive { get; set; } = true;

    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Order> Orders { get; set; } = new List<Order>(); 
    public ICollection<ChatMessage> SentMessages { get; set; } = new List<ChatMessage>();
    public ICollection<ChatMessage> ReceivedMessages { get; set; } = new List<ChatMessage>();
    public ICollection<AIChat> AIChats { get; set; } = new List<AIChat>();
}
