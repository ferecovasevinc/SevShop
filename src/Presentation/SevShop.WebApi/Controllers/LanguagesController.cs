using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.LanguageDtos;
using SevShop.Application.Shared;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguagesController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<List<LanguageGetDto>>>> GetAll()
    {
        var response = await _languageService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<LanguageGetDto>>> GetById(Guid id)
    {
        var response = await _languageService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<LanguageGetDto>>> Create([FromBody] LanguageCreateDto dto)
    {
        var response = await _languageService.CreateAsync(dto);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseResponse<LanguageGetDto>>> Update(Guid id, [FromBody] LanguageUpdateDto dto)
    {
        var response = await _languageService.UpdateAsync(id, dto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
    {
        var response = await _languageService.DeleteAsync(id);
        return Ok(response);
    }
}
