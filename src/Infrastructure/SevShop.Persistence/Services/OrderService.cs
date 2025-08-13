using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.OrderDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Net;

namespace SevShop.Persistence.Services;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository { get; }

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<BaseResponse<string>> CreateAsync(OrderCreateDto dto, string? userId)
    {
        if (!Guid.TryParse(userId, out Guid buyerGuid))
            return new BaseResponse<string>("Invalid user ID", null, HttpStatusCode.BadRequest);

        Order order = new()
        {
            Name = dto.Name,
            BuyerId = buyerGuid,
            OrderDate = DateTime.UtcNow,
            OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(100, 999)}",
            TotalPrice = dto.TotalPrice,
            TotalAmount = dto.TotalAmount,
            ShippingCost = dto.ShippingCost,
            ShippingAddress = dto.ShippingAddress,
            ShippingCity = dto.ShippingCity,
            ShippingPhone = dto.ShippingPhone,
            Notes = dto.Notes,
            Status = "Pending"
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangeAsync();

        return new BaseResponse<string>("Order created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<List<OrderListDto>>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAll().ToListAsync();

        var dtos = orders.Select(order => new OrderListDto
        {
            Id = order.Id,
            Name = order.Name,
            BuyerId = order.BuyerId,
            OrderDate = order.OrderDate,
            OrderNumber = order.OrderNumber,
            TotalPrice = order.TotalPrice,
            TotalAmount = order.TotalAmount,
            ShippingCost = order.ShippingCost,
            Status = order.Status
        }).ToList();

        return new BaseResponse<List<OrderListDto>>("Orders fetched", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<OrderListDto>>> GetMyOrdersAsync(string? userId)
    {
        if (!Guid.TryParse(userId, out Guid buyerGuid))
            return new BaseResponse<List<OrderListDto>>("Invalid user ID", null, HttpStatusCode.BadRequest);

        var orders = await _orderRepository
            .GetAll()
            .Where(o => o.BuyerId == buyerGuid)
            .ToListAsync();

        var dtos = orders.Select(order => new OrderListDto
        {
            Id = order.Id,
            Name = order.Name,
            BuyerId = order.BuyerId,
            OrderDate = order.OrderDate,
            OrderNumber = order.OrderNumber,
            TotalPrice = order.TotalPrice,
            TotalAmount = order.TotalAmount,
            ShippingCost = order.ShippingCost,
            Status = order.Status
        }).ToList();

        return new BaseResponse<List<OrderListDto>>("Orders fetched", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<OrderListDto>>> GetSalesAsync(string? userId)
    {
        if (!Guid.TryParse(userId, out Guid sellerGuid))
            return new BaseResponse<List<OrderListDto>>("Invalid user ID", null, HttpStatusCode.BadRequest);

        var orders = await _orderRepository
            .GetAll()
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .Where(o => o.OrderProducts.Any(op => op.Product.AppUserId == sellerGuid))
            .ToListAsync();

        var dtos = orders.Select(order => new OrderListDto
        {
            Id = order.Id,
            Name = order.Name,
            BuyerId = order.BuyerId,
            OrderDate = order.OrderDate,
            OrderNumber = order.OrderNumber,
            TotalPrice = order.TotalPrice,
            TotalAmount = order.TotalAmount,
            ShippingCost = order.ShippingCost,
            Status = order.Status
        }).ToList();

        return new BaseResponse<List<OrderListDto>>("Sales fetched", dtos, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<OrderDetailDto>> GetByIdAsync(Guid id, string? userId)
    {
        var order = await _orderRepository
            .GetAll()
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return new BaseResponse<OrderDetailDto>("Order not found", null, HttpStatusCode.NotFound);

        if (!Guid.TryParse(userId, out Guid currentUserGuid))
            return new BaseResponse<OrderDetailDto>("Invalid user ID", null, HttpStatusCode.BadRequest);

        var isBuyer = order.BuyerId == currentUserGuid;
        var isSeller = order.OrderProducts.Any(op => op.Product.AppUserId == currentUserGuid);

        if (!isBuyer && !isSeller)
            return new BaseResponse<OrderDetailDto>("Access denied", null, HttpStatusCode.Forbidden);

        OrderDetailDto dto = new OrderDetailDto
        {
            Id = order.Id,
            Name = order.Name,
            BuyerId = order.BuyerId,
            OrderDate = order.OrderDate,
            OrderNumber = order.OrderNumber,
            TotalPrice = order.TotalPrice,
            TotalAmount = order.TotalAmount,
            ShippingCost = order.ShippingCost,
            ShippingAddress = order.ShippingAddress,
            ShippingCity = order.ShippingCity,
            ShippingPhone = order.ShippingPhone,
            Notes = order.Notes,
            Status = order.Status,
            Products = order.OrderProducts.Select(op => new OrderProductDto
            {
                ProductId = op.ProductId,
                ProductName = op.Product.Name,
                Quantity = op.Quantity,
                Price = op.Price
            }).ToList()
        };

        return new BaseResponse<OrderDetailDto>("Order details", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> UpdateAsync(OrderUpdateDto dto)
    {
        var order = await _orderRepository.GetByIdAsync(dto.Id);
        if (order == null)
            return new BaseResponse<string>("Order not found", null, HttpStatusCode.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Status))
            order.Status = dto.Status;

        await _orderRepository.SaveChangeAsync();
        return new BaseResponse<string>("Order updated", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            return new BaseResponse<string>("Order not found", null, HttpStatusCode.NotFound);

        _orderRepository.Delete(order);
        await _orderRepository.SaveChangeAsync();

        return new BaseResponse<string>("Order deleted", HttpStatusCode.OK);
    }
}