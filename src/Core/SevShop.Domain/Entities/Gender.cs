namespace SevShop.Domain.Entities;

public class Gender : BaseEntity
{
    public string Name { get; set; } // "Kişi", "Qadın", "Uşaq"
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
