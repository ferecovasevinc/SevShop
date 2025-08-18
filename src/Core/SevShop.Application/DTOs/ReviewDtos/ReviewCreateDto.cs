namespace SevShop.Application.DTOs.ReviewDtos;

public class ReviewCreateDto
{
    public string Comment { get; set; }
    public int Rating { get; set; }
    public Guid AppUserId { get; set; }
    public Guid ProductId { get; set; }
}
