using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.BasketItemDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketItemsController : ControllerBase
{
    private readonly IBasketItemService _service;

    public BasketItemsController(IBasketItemService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(BasketItemCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, BasketItemUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("basket/{basketId}")]
    public async Task<IActionResult> GetByBasketId(Guid basketId)
    {
        var result = await _service.GetByBasketIdAsync(basketId);
        return Ok(result);
    }
}
