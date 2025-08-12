using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
    public ImageRepository(SevShopDbContext context) : base(context)
    {
    }
}
