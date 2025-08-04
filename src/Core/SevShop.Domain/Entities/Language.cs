namespace SevShop.Domain.Entities;

public class Language : BaseEntity
{
    public string Code { get; set; }  // en, az, ru
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
}
