using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.AIChatDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AIChatsController : ControllerBase
{
    private readonly IAIChatService _service;

    public AIChatsController(IAIChatService service)
    {
        _service = service;
    }

    // POST: api/aichat
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AIChatCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    // PUT: api/aichat
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AIChatUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _service.UpdateAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // GET: api/aichat/{userId}
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllByUser(Guid userId)
    {
        var result = await _service.GetAllByUserIdAsync(userId);
        return Ok(result);
    }
}
