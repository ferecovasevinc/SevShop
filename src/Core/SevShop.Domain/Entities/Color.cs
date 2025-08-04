namespace SevShop.Domain.Entities;

public class Color : BaseEntity
{
    public string Name { get; set; } // "Qara", "Ağ", "Qırmızı"
    public string HexCode { get; set; } 

    public bool IsDark { get; set; } // Qaranlıq/Açıq filter üçün

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
