using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ProductDtos;
using SevShop.Application.Shared.Extensions;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IFavoriteService _favoriteService;

    public ProductsController(IProductService productService, IFavoriteService favoriteService)
    {
        _productService = productService;
        _favoriteService = favoriteService;
    }

    // GET: /api/products
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] Guid? categoryId, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? search)
    {
        var response = await _productService.GetAllAsync(categoryId, minPrice, maxPrice, search);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: /api/products/{id}
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _productService.GetByIdAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: /api/products
    [HttpPost]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
    {
        var userId = User.GetUserId();
        var response = await _productService.CreateAsync(dto, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: /api/products/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateDto dto)
    {
        var userId = User.GetUserId();
        var response = await _productService.UpdateAsync(id, dto, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: /api/products/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();
        var response = await _productService.DeleteAsync(id, userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: /api/products/my
    [HttpGet("my")]
    [Authorize(Roles = "Seller")]
    public async Task<IActionResult> GetMyProducts()
    {
        var userId = User.GetUserId();
        var response = await _productService.GetMyProductsAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }
}
