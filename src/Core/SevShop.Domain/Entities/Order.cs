namespace SevShop.Domain.Entities;

public class Order : BaseEntity
{
    public string Name { get; set; }
    public Guid BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal ShippingCost { get; set; } = 0;

    public string ShippingAddress { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingPhone { get; set; }

    public string Status { get; set; } = "Pending";
    public string? Notes { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}
