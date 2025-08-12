using Microsoft.AspNetCore.Http;

namespace SevShop.Application.DTOs.FileUploadDtos;

public class FileUploadDto
{
    public IFormFile File { get; set; } = null!;
}

