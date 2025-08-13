using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
{
    public OrderProductRepository(SevShopDbContext context) : base(context)
    {
    }
}
