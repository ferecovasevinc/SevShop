namespace SevShop.Application.DTOs.OrderDtos;

public class OrderProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
