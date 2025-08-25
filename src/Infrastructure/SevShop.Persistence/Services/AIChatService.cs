using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.AIChatDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class AIChatService : IAIChatService
{
    private readonly IAIChatRepository _repository;

    public AIChatService(IAIChatRepository repository)
    {
        _repository = repository;
    }

    public async Task<AIChatGetDto> CreateAsync(AIChatCreateDto dto)
    {
        var entity = new AIChat
        {
            AppUserId = dto.AppUserId,
            UserMessage = dto.UserMessage,
            AIResponse = GenerateAIResponse(dto.UserMessage),
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangeAsync();

        return new AIChatGetDto
        {
            Id = entity.Id,
            AppUserId = entity.AppUserId,
            UserMessage = entity.UserMessage,
            AIResponse = entity.AIResponse,
            CreatedAt = entity.CreatedAt
        };
    }

    public async Task<AIChatGetDto> UpdateAsync(AIChatUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null)
            throw new Exception("AIChat not found");

        entity.UserMessage = dto.UserMessage;
        entity.AIResponse = dto.AIResponse;

        await _repository.SaveChangeAsync();

        return new AIChatGetDto
        {
            Id = entity.Id,
            AppUserId = entity.AppUserId,
            UserMessage = entity.UserMessage,
            AIResponse = entity.AIResponse,
            CreatedAt = entity.CreatedAt
        };
    }

    public async Task<List<AIChatGetDto>> GetAllByUserIdAsync(Guid userId)
    {
        var chats = await _repository.GetAllByUserIdAsync(userId);

        return chats.Select(c => new AIChatGetDto
        {
            Id = c.Id,
            AppUserId = c.AppUserId,
            UserMessage = c.UserMessage,
            AIResponse = c.AIResponse,
            CreatedAt = c.CreatedAt
        }).ToList();
    }

    private string GenerateAIResponse(string userMessage)
    {
        return $"AI cavabı: {userMessage}";
    }
}