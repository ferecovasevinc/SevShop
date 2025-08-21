using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface ILanguageRepository : IRepository<Language>
{
    Task<List<Language>> GetAllAsync();
    Task<Language?> GetByIdAsync(Guid id);
    Task SaveChangeAsync();
}
