namespace SevShop.Domain.Entities;

public class Size : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }
    public int SortOrder { get; set; }
    public ICollection<ProductSizeColor> ProductSizeColors { get; set; }
}
