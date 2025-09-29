using Microsoft.AspNetCore.Http;

namespace SevShop.Application.DTOs.CloudinaryDtos;

public class UploadFileDto
{
    public IFormFile File { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
