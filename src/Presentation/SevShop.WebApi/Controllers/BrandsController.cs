using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.BrandDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    // GET: api/brand
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _brandService.GetAllAsync();
        return Ok(brands);
    }

    // GET: api/brand/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var brand = await _brandService.GetByIdAsync(id);
        if (brand == null) return NotFound("Brand not found");
        return Ok(brand);
    }

    // POST: api/brand
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BrandCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var brand = await _brandService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
    }

    // PUT: api/brand/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] BrandUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updatedBrand = await _brandService.UpdateAsync(id, dto);
        if (updatedBrand == null) return NotFound("Brand not found");

        return Ok(updatedBrand);
    }

    // DELETE: api/brand/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _brandService.DeleteAsync(id);
        if (!result) return NotFound("Brand not found");

        return NoContent();
    }
}
