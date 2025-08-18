using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<List<Review>> GetReviewsByProductIdAsync(Guid productId);
}
