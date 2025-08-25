namespace SevShop.Application.DTOs.AIChatDtos;

public class AIChatUpdateDto
{
    public Guid Id { get; set; }
    public string UserMessage { get; set; }
    public string AIResponse { get; set; }
}
