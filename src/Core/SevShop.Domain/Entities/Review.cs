namespace SevShop.Domain.Entities;

public class Review : BaseEntity
{
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
