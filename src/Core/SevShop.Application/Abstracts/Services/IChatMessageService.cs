using SevShop.Application.DTOs.ChatMessageDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IChatMessageService
{
    Task<ChatMessageGetDto> CreateAsync(ChatMessageCreateDto dto);
    Task<ChatMessageGetDto> UpdateAsync(Guid id, ChatMessageUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task<ChatMessageGetDto> GetByIdAsync(Guid id);
    Task<List<ChatMessageGetDto>> GetAllAsync();
}