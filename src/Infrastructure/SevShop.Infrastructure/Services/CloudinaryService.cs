using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SevShop.Application.Abstracts.Services.CloudinaryService;
using SevShop.Application.Shared.Settings;

namespace SevShop.Infrastructure.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> config)
    {
        var settings = config.Value;

        Account account = new Account(
            settings.CloudName,
            settings.ApiKey,
            settings.ApiSecret);

        _cloudinary = new Cloudinary(account);
    }

    public string UploadImage(string filePath)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(filePath)
        };

        var uploadResult = _cloudinary.Upload(uploadParams);
        return uploadResult.SecureUrl.ToString();
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Fayl boşdur.");

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream)
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var errorMessage = uploadResult.Error?.Message ?? "Unknown error";
            throw new Exception($"Cloudinary upload failed: {errorMessage}");
        }

        return uploadResult.SecureUrl?.ToString() ?? throw new Exception("Upload URL is null.");
    }

}
