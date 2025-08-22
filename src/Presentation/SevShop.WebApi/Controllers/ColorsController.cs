using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ColorDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    private readonly IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _colorService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var color = await _colorService.GetByIdAsync(id);
        if (color == null) return NotFound();
        return Ok(color);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ColorCreateDto dto)
    {
        var color = await _colorService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = color.Id }, color);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ColorUpdateDto dto)
    {
        var color = await _colorService.UpdateAsync(id, dto);
        if (color == null) return NotFound();
        return Ok(color);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _colorService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
