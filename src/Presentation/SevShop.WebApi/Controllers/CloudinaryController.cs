using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services.CloudinaryService;
using SevShop.Application.DTOs.CloudinaryDtos;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CloudinaryController : ControllerBase
{
    private readonly ICloudinaryService _cloudinaryService;

    public CloudinaryController(ICloudinaryService cloudinaryService)
    {
        _cloudinaryService = cloudinaryService;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload([FromForm] UploadFileDto model)
    {
        if (model.File == null || model.File.Length == 0)
            return BadRequest("Fayl boşdur.");

        var url = await _cloudinaryService.UploadImageAsync(model.File);
        return Ok(new { Url = url });
    }
}
