using SevShop.Application.DTOs.BaketDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IBasketService
{
    Task<BasketGetDto> CreateAsync(BasketCreateDto dto);
    Task<BasketGetDto> UpdateAsync(Guid id, BasketUpdateDto dto);
    Task DeleteAsync(Guid id);
    Task<BasketGetDto?> GetByIdAsync(Guid id);
    Task<List<BasketGetDto>> GetAllAsync();
}
