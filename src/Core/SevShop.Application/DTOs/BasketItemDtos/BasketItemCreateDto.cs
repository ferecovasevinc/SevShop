namespace SevShop.Application.DTOs.BasketItemDtos;

public class BasketItemCreateDto
{
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
