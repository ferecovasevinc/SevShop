using SevShop.Application.DTOs.GenderDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IGenderService
{
    Task<List<GenderGetDto>> GetAllAsync();
    Task<GenderGetDto> GetByIdAsync(Guid id);
    Task CreateAsync(GenderCreateDto dto);
    Task UpdateAsync(GenderUpdateDto dto);
    Task DeleteAsync(Guid id);
}
