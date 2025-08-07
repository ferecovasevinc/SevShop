using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.CategoryDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Net;

namespace SevShop.Persistence.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository { get; }
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseResponse<string>> AddAsync(CategoryCreateDto dto)
    {
        var categoryDb = await _categoryRepository
            .GetByFiltered(c => c.Name.Trim().ToLower() == dto.Name.Trim().ToLower())
            .FirstOrDefaultAsync();
        if (categoryDb is not null)
        {
            return new BaseResponse<string>("This category already exist", HttpStatusCode.BadRequest);
        }

        Category category = new()
        {
            Name = dto.Name
        };
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangeAsync();
        return new BaseResponse<string>(HttpStatusCode.Created);
    }

    public async Task<BaseResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto)
    {
        var categoryDb = await _categoryRepository.GetByIdAsync(dto.Id);
        if (categoryDb is null)
        {
            return new BaseResponse<CategoryUpdateDto>(HttpStatusCode.NotFound);
        }

        var dtoName = dto.Name?.Trim().ToLower();
        var existedCategory = await _categoryRepository
            .GetByFiltered(c => c.Name != null && c.Name.Trim().ToLower() == dtoName)
            .FirstOrDefaultAsync();
        if (existedCategory is not null)
        {
            return new BaseResponse<CategoryUpdateDto>("This category already exist", HttpStatusCode.BadRequest);
        }
        categoryDb.Name = dto.Name;

        await _categoryRepository.SaveChangeAsync();
        return new BaseResponse<CategoryUpdateDto>("Successfully updated", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return new BaseResponse<string>("Category is not found", HttpStatusCode.NotFound);

        _categoryRepository.Delete(category);
        await _categoryRepository.SaveChangeAsync();

        return new BaseResponse<string>("Category has been deleted successfully", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<CategoryGetDto>>> GetAllAsync()
    {
        var categories = _categoryRepository.GetAll();
        if (categories is null)
            return new BaseResponse<List<CategoryGetDto>>(HttpStatusCode.NotFound);
        var dtoList = new List<CategoryGetDto>();
        foreach (var category in categories)
        {
            dtoList.Add(new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name,
            });
        }
        return new BaseResponse<List<CategoryGetDto>>("All data", dtoList, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<CategoryGetDto>> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return new BaseResponse<CategoryGetDto>(HttpStatusCode.NotFound);

        var dtoCategory = new CategoryGetDto
        {
            Id = category.Id,
            Name = category.Name
        };
        return new BaseResponse<CategoryGetDto>("Successfully", dtoCategory, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<CategoryGetDto>> GetByNameAsync(string search)
    {
        var categories = _categoryRepository.GetAll();
        var dtoCategory = new CategoryGetDto();
        foreach (var category in categories)
        {
            if (category.Name == search)
            {
                dtoCategory.Id = category.Id;
                dtoCategory.Name = category.Name;
            }
        }
        if (dtoCategory.Name is not null)
            return new BaseResponse<CategoryGetDto>("Successfully finded", dtoCategory, HttpStatusCode.OK);

        return new BaseResponse<CategoryGetDto>(HttpStatusCode.NotFound);
    }
}

