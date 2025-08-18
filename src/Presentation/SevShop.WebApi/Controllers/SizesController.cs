using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.SizeDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SizesController : ControllerBase
{
    private readonly ISizeService _service;

    public SizesController(ISizeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SizeCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok("Ölçü əlavə olundu");
    }

    [HttpPut]
    public async Task<IActionResult> Update(SizeUpdateDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok("Ölçü yeniləndi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok("Ölçü silindi");
    }
}
