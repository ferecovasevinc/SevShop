using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;
using System;

namespace SevShop.Persistence.Repositories;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    private readonly SevShopDbContext _context;

    public ReviewRepository(SevShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetReviewsByProductIdAsync(Guid productId)
    {
        return await _context.Reviews
            .Include(r => r.AppUser)
            .Include(r => r.Product)
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }
}