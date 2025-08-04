namespace SevShop.Domain.Entities;

public class ProductSizeColor : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid SizeId { get; set; }
    public Size Size { get; set; }

    public Guid ColorId { get; set; }
    public Color Color { get; set; }

    public int Quantity { get; set; }
}
