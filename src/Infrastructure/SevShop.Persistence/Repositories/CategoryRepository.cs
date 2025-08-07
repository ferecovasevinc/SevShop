using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(SevShopDbContext context) : base(context)
    {
    }
}
