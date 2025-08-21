namespace SevShop.Application.DTOs.LanguageDtos;

public class LanguageGetDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
