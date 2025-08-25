using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IBasketItemRepository : IRepository<BasketItem>
{
    Task<List<BasketItem>> GetByBasketIdAsync(Guid basketId);
}