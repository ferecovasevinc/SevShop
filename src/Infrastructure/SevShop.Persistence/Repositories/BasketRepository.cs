using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class BasketRepository : Repository<Basket>, IBasketRepository
{
    private readonly SevShopDbContext _context;

    public BasketRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Basket?> GetBasketWithItemsAsync(Guid id)
    {
        return await _context.Baskets
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}