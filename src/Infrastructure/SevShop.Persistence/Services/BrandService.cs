using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.BrandDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BrandGetDto>> GetAllAsync()
    {
        var brands = _repository.GetAll().ToList();
        return brands.Select(x => new BrandGetDto
        {
            Id = x.Id,
            Name = x.Name,
            LogoUrl = x.LogoUrl,
            Description = x.Description,
            IsActive = x.IsActive
        }).ToList();
    }

    public async Task<BrandGetDto?> GetByIdAsync(Guid id)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand == null) return null;

        return new BrandGetDto
        {
            Id = brand.Id,
            Name = brand.Name,
            LogoUrl = brand.LogoUrl,
            Description = brand.Description,
            IsActive = brand.IsActive
        };
    }

    public async Task<BrandGetDto> CreateAsync(BrandCreateDto dto)
    {
        var brand = new Brand
        {
            Name = dto.Name,
            LogoUrl = dto.LogoUrl,
            Description = dto.Description,
            IsActive = true
        };

        await _repository.AddAsync(brand);
        await _repository.SaveChangeAsync();

        return new BrandGetDto
        {
            Id = brand.Id,
            Name = brand.Name,
            LogoUrl = brand.LogoUrl,
            Description = brand.Description,
            IsActive = brand.IsActive
        };
    }

    public async Task<BrandGetDto?> UpdateAsync(Guid id, BrandUpdateDto dto)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand == null) return null;

        brand.Name = dto.Name;
        brand.LogoUrl = dto.LogoUrl;
        brand.Description = dto.Description;
        brand.IsActive = dto.IsActive;

        _repository.Update(brand);
        await _repository.SaveChangeAsync();

        return new BrandGetDto
        {
            Id = brand.Id,
            Name = brand.Name,
            LogoUrl = brand.LogoUrl,
            Description = brand.Description,
            IsActive = brand.IsActive
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand == null) return false;

        _repository.Delete(brand);
        await _repository.SaveChangeAsync();

        return true;
    }
}
