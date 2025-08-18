namespace SevShop.Application.DTOs.ReviewDtos;

public class ReviewGetDto
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; }
    public string ProductName { get; set; }
}
