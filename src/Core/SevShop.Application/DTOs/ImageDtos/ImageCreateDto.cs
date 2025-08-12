namespace SevShop.Application.DTOs.ImageDtos;

public class ImageCreateDto
{
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
    public Guid ProductId { get; set; }
}
