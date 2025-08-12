using Microsoft.AspNetCore.Http;

namespace SevShop.Application.Abstracts.Services;

public interface IFileUpload
{
    Task<string> UploadAsync(IFormFile file);
}
