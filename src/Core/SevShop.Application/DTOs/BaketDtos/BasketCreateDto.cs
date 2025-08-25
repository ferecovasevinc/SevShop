namespace SevShop.Application.DTOs.BaketDtos;

public class BasketCreateDto
{
    public Guid BuyerId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
