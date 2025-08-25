using SevShop.Application.DTOs.BasketItemDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IBasketItemService
{
    Task<BasketItemGetDto> CreateAsync(BasketItemCreateDto dto);
    Task<BasketItemGetDto?> UpdateAsync(Guid id, BasketItemUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<BasketItemGetDto?> GetByIdAsync(Guid id);
    Task<List<BasketItemGetDto>> GetByBasketIdAsync(Guid basketId);
}
