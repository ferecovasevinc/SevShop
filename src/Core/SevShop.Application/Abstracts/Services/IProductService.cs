using SevShop.Application.DTOs.ProductDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface IProductService
{
    Task<BaseResponse<List<ProductListDto>>> GetAllAsync(Guid? categoryId, decimal? minPrice, decimal? maxPrice, string? search);
    Task<BaseResponse<ProductDetailDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<string>> CreateAsync(ProductCreateDto dto, Guid userId);
    Task<BaseResponse<string>> UpdateAsync(Guid id, ProductUpdateDto dto, Guid userId);
    Task<BaseResponse<string>> DeleteAsync(Guid id, Guid userId);
    Task<BaseResponse<List<ProductListDto>>> GetMyProductsAsync(Guid userId);
}
