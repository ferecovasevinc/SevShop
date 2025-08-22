using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class GenderRepository : Repository<Gender>, IGenderRepository
{
    private readonly SevShopDbContext _context;

    public GenderRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Gender> GetByNameAsync(string name)
    {
        return await _context.Genders
            .FirstOrDefaultAsync(x => x.Name == name);
    }
}