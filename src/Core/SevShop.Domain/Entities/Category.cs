namespace SevShop.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string SubName { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
