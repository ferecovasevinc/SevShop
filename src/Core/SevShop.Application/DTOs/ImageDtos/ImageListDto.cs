namespace SevShop.Application.DTOs.ImageDtos;

public class ImageListDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
    public Guid ProductId { get; set; }
}
