using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ProductDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Linq.Expressions;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SevShop.Persistence.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository { get; }
    private ICategoryRepository _categoryRepository { get; }

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseResponse<string>> CreateAsync(ProductCreateDto dto, Guid userId)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null)
            return new BaseResponse<string>("Category not found", false, HttpStatusCode.NotFound);

        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            AppUserId = userId
        };

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangeAsync();

        return new BaseResponse<string>("Product created successfully", true, HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id, Guid userId)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return new BaseResponse<string>("Product not found", false, HttpStatusCode.NotFound);

        if (product.AppUserId != userId)
            return new BaseResponse<string>("You are not allowed to delete this product", false, HttpStatusCode.Forbidden);

        _productRepository.Delete(product);
        await _productRepository.SaveChangeAsync();

        return new BaseResponse<string>("Product deleted successfully", true, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<ProductListDto>>> GetAllAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search)
    {
        var products = await _productRepository.GetFilteredAsync(categoryId, minPrice, maxPrice, search);

        var dto = products.Select(p => new ProductListDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryName = p.Category.Name,
            ImageUrls = p.Images.Select(i => i.ImageUrl).ToList()
        }).ToList();

        return new BaseResponse<List<ProductListDto>>("Products fetched successfully", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<ProductDetailDto>> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByFiltered(p => p.Id == id,
            new Expression<Func<Product, object>>[]
            {
                p => p.Category,
                p => p.Images,
                p => p.AppUser
            }).FirstOrDefaultAsync();

        if (product is null)
            return new BaseResponse<ProductDetailDto>("Product not found", false, HttpStatusCode.NotFound);

        var dto = new ProductDetailDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            OwnerName = product.AppUser.UserName,
            ImageUrls = product.Images.Select(i => i.ImageUrl).ToList()
        };

        return new BaseResponse<ProductDetailDto>("Product fetched successfully", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<ProductListDto>>> GetMyProductsAsync(Guid userId)
    {
        var products = await _productRepository.GetMyProductsAsync(userId);

        var dto = products.Select(p => new ProductListDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryName = p.Category.Name,
            ImageUrls = p.Images.Select(i => i.ImageUrl).ToList()
        }).ToList();

        return new BaseResponse<List<ProductListDto>>("My products fetched successfully", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> UpdateAsync(Guid id, ProductUpdateDto dto, Guid userId)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
            return new BaseResponse<string>("Product not found", false, HttpStatusCode.NotFound);

        if (product.AppUserId != userId)
            return new BaseResponse<string>("You are not allowed to update this product", false, HttpStatusCode.Forbidden);

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category is null)
            return new BaseResponse<string>("Category not found", false, HttpStatusCode.NotFound);

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;

        _productRepository.Update(product);
        await _productRepository.SaveChangeAsync();

        return new BaseResponse<string>("Product updated successfully", true, HttpStatusCode.OK);
    }
}
