namespace SevShop.Application.DTOs.AIChatDtos;

public class AIChatCreateDto
{
    public Guid AppUserId { get; set; }
    public string UserMessage { get; set; }
}
