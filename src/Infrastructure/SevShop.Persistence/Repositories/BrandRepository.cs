using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    private readonly SevShopDbContext _context;

    public BrandRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetAllActiveAsync()
    {
        return await _context.Brands.Where(x => x.IsActive).ToListAsync();
    }
}
