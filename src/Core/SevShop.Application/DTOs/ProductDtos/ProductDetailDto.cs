namespace SevShop.Application.DTOs.ProductDtos;

public class ProductDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockCount { get; set; }
    public decimal? DiscountPrice { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsNew { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public string OwnerName { get; set; }
    public List<string> ImageUrls { get; set; }
}
