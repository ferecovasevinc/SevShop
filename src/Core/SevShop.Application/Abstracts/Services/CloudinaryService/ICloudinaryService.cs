using Microsoft.AspNetCore.Http;

namespace SevShop.Application.Abstracts.Services.CloudinaryService;

public interface ICloudinaryService
{
    string UploadImage(string filePath);
    Task<string> UploadImageAsync(IFormFile file);
}

