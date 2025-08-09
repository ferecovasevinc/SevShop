using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;
namespace SevShop.Persistence.Repositories;

public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
{
    private readonly SevShopDbContext _context;

    public FavoriteRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Favorite>> GetFavoritesByUserIdAsync(Guid userId)
    {
        return await _context.Favorites
                             .Where(f => f.AppUserId == userId)
                             .ToListAsync();
    }
}