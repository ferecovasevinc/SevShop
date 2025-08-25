using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
{
    private readonly SevShopDbContext _context;

    public BasketItemRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<BasketItem>> GetByBasketIdAsync(Guid basketId)
    {
        return await _context.BasketItems
            .Where(bi => bi.BasketId == basketId)
            .ToListAsync();
    }
}

