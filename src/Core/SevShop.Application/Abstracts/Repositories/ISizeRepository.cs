using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface ISizeRepository : IRepository<Size>
{
    Task<List<Size>> GetAllSortedAsync();
}
