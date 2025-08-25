namespace SevShop.Application.DTOs.BrandDtos;

public class BrandUpdateDto
{
    public string Name { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
