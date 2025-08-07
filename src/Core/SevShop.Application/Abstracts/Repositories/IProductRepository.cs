using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetAllWithIncludesAsync();
    Task<List<Product>> GetFilteredAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search);
    Task<List<Product>> GetMyProductsAsync(Guid userId);

}
