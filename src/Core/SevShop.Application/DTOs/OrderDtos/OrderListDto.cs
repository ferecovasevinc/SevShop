namespace SevShop.Application.DTOs.OrderDtos;

public class OrderListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal ShippingCost { get; set; }
    public string Status { get; set; } = null!;
}
