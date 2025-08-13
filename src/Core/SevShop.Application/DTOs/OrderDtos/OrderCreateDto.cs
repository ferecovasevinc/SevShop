namespace SevShop.Application.DTOs.OrderDtos;

public class OrderCreateDto
{
    public string Name { get; set; } = null!;
    public Guid BuyerId { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public string ShippingAddress { get; set; } = null!;
    public string ShippingCity { get; set; } = null!;
    public string ShippingPhone { get; set; } = null!;
    public string? Notes { get; set; }
    public List<Guid> ProductIds { get; set; } = new();
}
