namespace SevShop.Domain.Entities;

public class Size : BaseEntity
{
    public string Name { get; set; } // "S", "M", "L", "XL", "38", "39"

    public string? Description { get; set; } // "Kiçik", "Orta", "Böyük"
    public int SortOrder { get; set; } // Sıralama üçün
    public ICollection<ProductSizeColor> ProductSizeColors { get; set; }
}
