namespace SevShop.Application.DTOs.OrderDtos;

public class OrderDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public string ShippingAddress { get; set; } = null!;
    public string ShippingCity { get; set; } = null!;
    public string ShippingPhone { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? Notes { get; set; }

    public List<OrderProductDto> Products { get; set; } = new();
}
