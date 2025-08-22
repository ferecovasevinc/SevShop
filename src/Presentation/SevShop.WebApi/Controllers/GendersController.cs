using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.GenderDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GendersController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GendersController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    // GET: api/Gender
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genders = await _genderService.GetAllAsync();
        return Ok(genders);
    }

    // GET: api/Gender/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var gender = await _genderService.GetByIdAsync(id);
            return Ok(gender);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST: api/Gender
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenderCreateDto dto)
    {
        await _genderService.CreateAsync(dto);
        return Ok("Gender yaradıldı");
    }

    // PUT: api/Gender
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GenderUpdateDto dto)
    {
        try
        {
            await _genderService.UpdateAsync(dto);
            return Ok("Gender yeniləndi");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // DELETE: api/Gender/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _genderService.DeleteAsync(id);
            return Ok("Gender silindi");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
