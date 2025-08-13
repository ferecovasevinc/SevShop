using SevShop.Application.DTOs.OrderProductDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface IOrderProductService
{
    Task<BaseResponse<string>> CreateAsync(OrderProductCreateDto dto);
    Task<BaseResponse<string>> UpdateAsync(OrderProductUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
    Task<BaseResponse<List<OrderProductListDto>>> GetAllAsync();
    Task<BaseResponse<OrderProductListDto>> GetByIdAsync(Guid id);
}
