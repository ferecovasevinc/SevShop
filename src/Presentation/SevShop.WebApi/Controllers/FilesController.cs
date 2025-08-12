using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.FileUploadDtos;

namespace SevShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileUpload _fileUpload;
        public FilesController(IFileUpload fileUpload)
        {
            _fileUpload = fileUpload;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadDto dto)
        {
            var fileUrl = await _fileUpload.UploadAsync(dto.File);
            return Ok(new { FileUrl = fileUrl });
        }
    }
}
