namespace SevShop.Domain.Entities;

public class Favorite : BaseEntity
{
    public string Name { get; set; }

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
