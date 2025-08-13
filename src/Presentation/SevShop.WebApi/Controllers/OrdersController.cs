using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.OrderDtos;
using SevShop.Application.Shared;
using System.Net;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // POST /api/orders
    [HttpPost]
    [Authorize(Roles = "Buyer")]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] OrderCreateDto dto)
    {
        var userId = User.Identity?.Name;
        var response = await _orderService.CreateAsync(dto, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET /api/orders/my
    [HttpGet("my")]
    [Authorize(Roles = "Buyer")]
    [ProducesResponseType(typeof(BaseResponse<List<OrderListDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMyOrders()
    {
        var userId = User.Identity?.Name;
        var response = await _orderService.GetMyOrdersAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET /api/orders/my-sales
    [HttpGet("my-sales")]
    [Authorize(Roles = "Seller")]
    [ProducesResponseType(typeof(BaseResponse<List<OrderListDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSales()
    {
        var userId = User.Identity?.Name;
        var response = await _orderService.GetSalesAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET /api/orders/{id}
    [HttpGet("{id}")]
    [Authorize(Roles = "Buyer,Seller")]
    [ProducesResponseType(typeof(BaseResponse<OrderDetailDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<OrderDetailDto>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = User.Identity?.Name;
        var response = await _orderService.GetByIdAsync(id, userId);
        return StatusCode((int)response.StatusCode, response);
    }
}
