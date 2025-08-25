using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IBrandRepository : IRepository<Brand>
{
    Task<List<Brand>> GetAllActiveAsync();
}
