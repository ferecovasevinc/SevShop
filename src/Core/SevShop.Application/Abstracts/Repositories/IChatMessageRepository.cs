using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IChatMessageRepository
{
    Task<ChatMessage> GetByIdAsync(Guid id);
    Task<List<ChatMessage>> GetAllAsync();
    Task AddAsync(ChatMessage chatMessage);
    Task UpdateAsync(ChatMessage chatMessage);
    Task DeleteAsync(ChatMessage chatMessage);
}