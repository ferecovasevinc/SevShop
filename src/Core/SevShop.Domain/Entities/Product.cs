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

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }

    public Guid GenderId { get; set; }
    public Gender Gender { get; set; }

    public ICollection<ProductSizeColor> ProductSizeColors { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

}
