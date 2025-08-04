namespace SevShop.Domain.Entities;

public class BasketItem : BaseEntity
{
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
