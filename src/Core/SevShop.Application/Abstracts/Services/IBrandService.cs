using SevShop.Application.DTOs.BrandDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IBrandService
{
    Task<List<BrandGetDto>> GetAllAsync();
    Task<BrandGetDto?> GetByIdAsync(Guid id);
    Task<BrandGetDto> CreateAsync(BrandCreateDto dto);
    Task<BrandGetDto?> UpdateAsync(Guid id, BrandUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}
