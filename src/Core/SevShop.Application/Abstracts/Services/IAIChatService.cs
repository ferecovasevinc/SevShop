using SevShop.Application.DTOs.AIChatDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IAIChatService
{
    Task<AIChatGetDto> CreateAsync(AIChatCreateDto dto);
    Task<List<AIChatGetDto>> GetAllByUserIdAsync(Guid userId);
    Task<AIChatGetDto> UpdateAsync(AIChatUpdateDto dto);
}