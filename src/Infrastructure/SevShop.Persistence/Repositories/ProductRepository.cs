using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly SevShopDbContext _context;

    public ProductRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllWithIncludesAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Gender)
            .ToListAsync();
    }

    public async Task<List<Product>> GetMyProductsAsync(Guid userId)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Where(p => p.AppUserId == userId)
            .ToListAsync();
    }

    public async Task<List<Product>> GetFilteredAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Images)
            .AsQueryable();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));

        return await query.ToListAsync();
    }

}
