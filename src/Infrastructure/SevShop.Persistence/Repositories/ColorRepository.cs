using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class ColorRepository : IColorRepository
{
    private readonly SevShopDbContext _context;

    public ColorRepository(SevShopDbContext context)
    {
        _context = context;
    }

    public async Task<List<Color>> GetAllAsync()
        => await _context.Colors.ToListAsync();

    public async Task<Color> GetByIdAsync(Guid id)
        => await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Color color)
    {
        await _context.Colors.AddAsync(color);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Color color)
    {
        _context.Colors.Update(color);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Color color)
    {
        _context.Colors.Remove(color);
        await _context.SaveChangesAsync();
    }
}
