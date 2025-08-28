namespace SevShop.Domain.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; }
    public string HexCode { get; set; }

    public bool IsDark { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
