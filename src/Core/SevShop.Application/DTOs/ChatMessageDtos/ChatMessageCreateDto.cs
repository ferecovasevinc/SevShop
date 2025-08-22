namespace SevShop.Application.DTOs.ChatMessageDtos;

public class ChatMessageCreateDto
{
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Message { get; set; }
}
