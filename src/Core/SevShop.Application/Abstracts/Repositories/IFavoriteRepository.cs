using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IFavoriteRepository : IRepository<Favorite>
{
    Task<List<Favorite>> GetFavoritesByUserIdAsync(Guid userId);
}
