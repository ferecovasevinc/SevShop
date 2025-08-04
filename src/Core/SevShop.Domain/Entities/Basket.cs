namespace SevShop.Domain.Entities;

public class Basket : BaseEntity
{
    public Guid BuyerId { get; set; }
    public DateTime CreatedDate { get; set; }

    public ICollection<BasketItem> Items { get; set; }
}
