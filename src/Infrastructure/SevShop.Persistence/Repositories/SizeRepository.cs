using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;
using System;

namespace SevShop.Persistence.Repositories;

public class SizeRepository : Repository<Size>, ISizeRepository
{
    private readonly SevShopDbContext _context;

    public SizeRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Size>> GetAllSortedAsync()
    {
        return await _context.Sizes
            .OrderBy(s => s.SortOrder)
            .ToListAsync();
    }
}