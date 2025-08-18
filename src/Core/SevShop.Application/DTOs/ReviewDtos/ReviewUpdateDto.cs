namespace SevShop.Application.DTOs.ReviewDtos;

public class ReviewUpdateDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}