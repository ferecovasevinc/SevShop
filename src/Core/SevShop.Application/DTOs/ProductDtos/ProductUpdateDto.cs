namespace SevShop.Application.DTOs.ProductDtos;

public class ProductUpdateDto 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int StockCount { get; set; }
    public string? SKU { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; } = false;
    public bool IsNew { get; set; } = true;
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid GenderId { get; set; }
}
