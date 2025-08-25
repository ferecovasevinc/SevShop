namespace SevShop.Application.DTOs.AIChatDtos;

public class AIChatGetDto
{
    public Guid Id { get; set; }
    public Guid AppUserId { get; set; }
    public string UserMessage { get; set; }
    public string AIResponse { get; set; }
    public DateTime CreatedAt { get; set; }
}
