using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.SizeDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _repository;

    public SizeService(ISizeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SizeGetDto>> GetAllAsync()
    {
        var sizes = await _repository.GetAllSortedAsync();
        return sizes.Select(s => new SizeGetDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            SortOrder = s.SortOrder
        }).ToList();
    }

    public async Task<SizeGetDto> GetByIdAsync(Guid id)
    {
        var size = await _repository.GetByIdAsync(id);
        if (size == null) throw new Exception("Ölçü tapılmadı");

        return new SizeGetDto
        {
            Id = size.Id,
            Name = size.Name,
            Description = size.Description,
            SortOrder = size.SortOrder
        };
    }

    public async Task CreateAsync(SizeCreateDto dto)
    {
        var size = new Size
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            SortOrder = dto.SortOrder
        };

        await _repository.AddAsync(size);
        await _repository.SaveChangeAsync();
    }

    public async Task UpdateAsync(SizeUpdateDto dto)
    {
        var size = await _repository.GetByIdAsync(dto.Id);
        if (size == null) throw new Exception("Ölçü tapılmadı");

        size.Name = dto.Name;
        size.Description = dto.Description;
        size.SortOrder = dto.SortOrder;

        _repository.Update(size);
        await _repository.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var size = await _repository.GetByIdAsync(id);
        if (size == null) throw new Exception("Ölçü tapılmadı");

        _repository.Delete(size);
        await _repository.SaveChangeAsync();
    }
}