using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IGenderRepository : IRepository<Gender>
{
    Task<Gender> GetByNameAsync(string name);
}