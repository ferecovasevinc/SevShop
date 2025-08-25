using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IBasketRepository : IRepository<Basket>
{
    Task<Basket?> GetBasketWithItemsAsync(Guid id);
}
