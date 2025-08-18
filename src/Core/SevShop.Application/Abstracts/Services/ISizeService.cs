using SevShop.Application.DTOs.SizeDtos;

namespace SevShop.Application.Abstracts.Services;

public interface ISizeService
{
    Task<List<SizeGetDto>> GetAllAsync();
    Task<SizeGetDto> GetByIdAsync(Guid id);
    Task CreateAsync(SizeCreateDto dto);
    Task UpdateAsync(SizeUpdateDto dto);
    Task DeleteAsync(Guid id);
}
