namespace SevShop.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; } // "Nike", "Adidas", "Zara"

    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
