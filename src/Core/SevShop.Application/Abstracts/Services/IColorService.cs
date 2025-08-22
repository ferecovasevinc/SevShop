using SevShop.Application.DTOs.ColorDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IColorService
{
    Task<List<ColorGetDto>> GetAllAsync();
    Task<ColorGetDto> GetByIdAsync(Guid id);
    Task<ColorGetDto> CreateAsync(ColorCreateDto dto);
    Task<ColorGetDto> UpdateAsync(Guid id, ColorUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}
