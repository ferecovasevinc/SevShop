namespace SevShop.Application.DTOs.BaketDtos;

public class BasketGetDto
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<Guid> ItemIds { get; set; } = new();
}

