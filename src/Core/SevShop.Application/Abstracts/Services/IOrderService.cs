using SevShop.Application.DTOs.OrderDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface IOrderService
{
    Task<BaseResponse<string>> CreateAsync(OrderCreateDto dto, string? userId);
    Task<BaseResponse<List<OrderListDto>>> GetMyOrdersAsync(string? userId);
    Task<BaseResponse<List<OrderListDto>>> GetSalesAsync(string? userId);
    Task<BaseResponse<OrderDetailDto>> GetByIdAsync(Guid id, string? userId);
}
