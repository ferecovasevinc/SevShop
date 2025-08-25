using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.BasketItemDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class BasketItemService : IBasketItemService
{
    private readonly IBasketItemRepository _repository;

    public BasketItemService(IBasketItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<BasketItemGetDto> CreateAsync(BasketItemCreateDto dto)
    {
        var entity = new BasketItem
        {
            BasketId = dto.BasketId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Price = dto.Price
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangeAsync();

        return new BasketItemGetDto
        {
            Id = entity.Id,
            BasketId = entity.BasketId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            Price = entity.Price
        };
    }

    public async Task<BasketItemGetDto?> UpdateAsync(Guid id, BasketItemUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        entity.Quantity = dto.Quantity;
        entity.Price = dto.Price;

        _repository.Update(entity);
        await _repository.SaveChangeAsync();

        return new BasketItemGetDto
        {
            Id = entity.Id,
            BasketId = entity.BasketId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            Price = entity.Price
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Delete(entity);
        await _repository.SaveChangeAsync();
        return true;
    }

    public async Task<BasketItemGetDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        return new BasketItemGetDto
        {
            Id = entity.Id,
            BasketId = entity.BasketId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            Price = entity.Price
        };
    }

    public async Task<List<BasketItemGetDto>> GetByBasketIdAsync(Guid basketId)
    {
        var entities = await _repository.GetByBasketIdAsync(basketId);
        return entities.Select(e => new BasketItemGetDto
        {
            Id = e.Id,
            BasketId = e.BasketId,
            ProductId = e.ProductId,
            Quantity = e.Quantity,
            Price = e.Price
        }).ToList();
    }
}
