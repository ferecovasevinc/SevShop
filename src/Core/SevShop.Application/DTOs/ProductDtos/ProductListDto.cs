namespace SevShop.Application.DTOs.ProductDtos;

public class ProductListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public string BrandName { get; set; }
    public string GenderName { get; set; }
    public List<string> ImageUrls { get; set; }

}
