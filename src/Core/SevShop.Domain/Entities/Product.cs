using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace SevShop.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? DiscountPrice { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    public string? SKU { get; set; } // Məhsul kodu
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; } = false; // Xüsusi məhsul
    public bool IsNew { get; set; } = true;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public int GenderId { get; set; }
    public Gender Gender { get; set; }

    public ICollection<ProductSizeColor> ProductSizeColors { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}
