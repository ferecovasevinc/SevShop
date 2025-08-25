using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.BaketDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _repository;

    public BasketService(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<BasketGetDto> CreateAsync(BasketCreateDto dto)
    {
        var basket = new Basket
        {
            BuyerId = dto.BuyerId,
            CreatedDate = dto.CreatedDate
        };

        await _repository.AddAsync(basket);
        await _repository.SaveChangeAsync();

        return new BasketGetDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            CreatedDate = basket.CreatedDate
        };
    }

    public async Task<BasketGetDto> UpdateAsync(Guid id, BasketUpdateDto dto)
    {
        var basket = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Basket tapılmadı");

        basket.BuyerId = dto.BuyerId;

        _repository.Update(basket);
        await _repository.SaveChangeAsync();

        return new BasketGetDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            CreatedDate = basket.CreatedDate
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var basket = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Basket tapılmadı");

        _repository.Delete(basket);
        await _repository.SaveChangeAsync();
    }

    public async Task<BasketGetDto?> GetByIdAsync(Guid id)
    {
        var basket = await _repository.GetBasketWithItemsAsync(id);
        if (basket == null) return null;

        return new BasketGetDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            CreatedDate = basket.CreatedDate,
            ItemIds = basket.Items.Select(i => i.Id).ToList()
        };
    }

    public async Task<List<BasketGetDto>> GetAllAsync()
    {
        var baskets = await _repository.GetAll().Include(b => b.Items).ToListAsync();
        return baskets.Select(b => new BasketGetDto
        {
            Id = b.Id,
            BuyerId = b.BuyerId,
            CreatedDate = b.CreatedDate,
            ItemIds = b.Items.Select(i => i.Id).ToList()
        }).ToList();
    }
}
