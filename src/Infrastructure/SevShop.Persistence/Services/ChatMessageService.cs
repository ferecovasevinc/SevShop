using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ChatMessageDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class ChatMessageService : IChatMessageService
{
    private readonly IChatMessageRepository _repository;

    public ChatMessageService(IChatMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChatMessageGetDto> CreateAsync(ChatMessageCreateDto dto)
    {
        var entity = new ChatMessage
        {
            Id = Guid.NewGuid(),
            SenderId = dto.SenderId,
            ReceiverId = dto.ReceiverId,
            Message = dto.Message,
            SentAt = DateTime.UtcNow,
            IsRead = false
        };

        await _repository.AddAsync(entity);

        return new ChatMessageGetDto
        {
            Id = entity.Id,
            SenderId = entity.SenderId,
            SenderName = entity.Sender?.UserName,
            ReceiverId = entity.ReceiverId,
            ReceiverName = entity.Receiver?.UserName,
            Message = entity.Message,
            SentAt = entity.SentAt,
            IsRead = entity.IsRead
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity != null)
            await _repository.DeleteAsync(entity);
    }

    public async Task<List<ChatMessageGetDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(c => new ChatMessageGetDto
        {
            Id = c.Id,
            SenderId = c.SenderId,
            SenderName = c.Sender?.UserName,
            ReceiverId = c.ReceiverId,
            ReceiverName = c.Receiver?.UserName,
            Message = c.Message,
            SentAt = c.SentAt,
            IsRead = c.IsRead
        }).ToList();
    }

    public async Task<ChatMessageGetDto> GetByIdAsync(Guid id)
    {
        var c = await _repository.GetByIdAsync(id);
        if (c == null) return null;

        return new ChatMessageGetDto
        {
            Id = c.Id,
            SenderId = c.SenderId,
            SenderName = c.Sender?.UserName,
            ReceiverId = c.ReceiverId,
            ReceiverName = c.Receiver?.UserName,
            Message = c.Message,
            SentAt = c.SentAt,
            IsRead = c.IsRead
        };
    }

    public async Task<ChatMessageGetDto> UpdateAsync(Guid id, ChatMessageUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        entity.Message = dto.Message;
        entity.IsRead = dto.IsRead;

        await _repository.UpdateAsync(entity);

        return new ChatMessageGetDto
        {
            Id = entity.Id,
            SenderId = entity.SenderId,
            SenderName = entity.Sender?.UserName,
            ReceiverId = entity.ReceiverId,
            ReceiverName = entity.Receiver?.UserName,
            Message = entity.Message,
            SentAt = entity.SentAt,
            IsRead = entity.IsRead
        };
    }
}