namespace SevShop.Application.DTOs.BrandDtos;

public class BrandCreateDto
{
    public string Name { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
}
