namespace SevShop.Application.DTOs.ChatMessageDtos;

public class ChatMessageCreateDto
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Message { get; set; }
}
