using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.CategoryDtos;
using SevShop.Application.Shared;
using System.Net;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/category
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<CategoryGetDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        return StatusCode((int)result.StatusCode, result);
    }

    // GET: api/category/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BaseResponse<CategoryGetDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }

    // POST: api/category
    [HttpPost]
    [Authorize(Policy = Permissions.Category.Create)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
    {
        var result = await _categoryService.AddAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    // PUT: api/category/{id}
    [HttpPut("{id}")]
    [Authorize(Policy = Permissions.Category.Update)]
    [ProducesResponseType(typeof(BaseResponse<CategoryUpdateDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryUpdateDto dto)
    {
        dto.Id = id; // ID-ni DTO-ya əlavə et
        var result = await _categoryService.UpdateAsync(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    // DELETE: api/category/{id}
    [HttpDelete("{id}")]
    [Authorize(Policy = Permissions.Category.Delete)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return StatusCode((int)result.StatusCode, result);
    }
}
