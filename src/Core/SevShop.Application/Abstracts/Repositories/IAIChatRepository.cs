using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IAIChatRepository : IRepository<AIChat>
{
    Task<List<AIChat>> GetAllByUserIdAsync(Guid userId);
}
