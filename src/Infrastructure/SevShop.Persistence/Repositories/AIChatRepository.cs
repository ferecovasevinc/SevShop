using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class AIChatRepository : Repository<AIChat>, IAIChatRepository
{
    private readonly SevShopDbContext _context;

    public AIChatRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<AIChat>> GetAllByUserIdAsync(Guid userId)
    {
        return await _context.AIChats
                             .Where(a => a.AppUserId == userId)
                             .OrderByDescending(a => a.CreatedAt)
                             .ToListAsync();
    }
}