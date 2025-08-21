using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class LanguageRepository : Repository<Language>, ILanguageRepository
{
    private readonly SevShopDbContext _context;

    public LanguageRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Language>> GetAllAsync()
    {
        return await _context.Set<Language>().ToListAsync();
    }

    public async Task<Language?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Language>().FindAsync(id);
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}