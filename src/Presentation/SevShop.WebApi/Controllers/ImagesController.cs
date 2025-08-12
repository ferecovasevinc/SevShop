using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ImageDtos;
using SevShop.Application.Shared;
using System.Net;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _imageService.GetAllAsync();
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _imageService.GetByIdAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] ImageCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _imageService.CreateAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] ImageUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _imageService.UpdateAsync(id, dto);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _imageService.DeleteAsync(id);
        return StatusCode((int)response.StatusCode, response);
    }
}
