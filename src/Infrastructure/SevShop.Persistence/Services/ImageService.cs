using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ImageDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Net;

namespace SevShop.Persistence.Services;

public class ImageService : IImageService
{
    private IImageRepository _imageRepository { get; }

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<BaseResponse<List<ImageListDto>>> GetAllAsync()
    {
        var images = await _imageRepository.GetAll().ToListAsync();

        var dto = images.Select(i => new ImageListDto
        {
            Id = i.Id,
            ImageUrl = i.ImageUrl,
            IsMain = i.IsMain,
            ProductId = i.ProductId
        }).ToList();

        return new BaseResponse<List<ImageListDto>>("Images fetched", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<ImageListDto>> GetByIdAsync(Guid id)
    {
        var image = await _imageRepository.GetByIdAsync(id);
        if (image == null)
            return new BaseResponse<ImageListDto>("Image not found", null, HttpStatusCode.NotFound);

        var dto = new ImageListDto
        {
            Id = image.Id,
            ImageUrl = image.ImageUrl,
            IsMain = image.IsMain,
            ProductId = image.ProductId
        };

        return new BaseResponse<ImageListDto>("Image fetched", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> CreateAsync(ImageCreateDto dto)
    {
        var image = new Image
        {
            ImageUrl = dto.ImageUrl,
            IsMain = dto.IsMain,
            ProductId = dto.ProductId
        };

        await _imageRepository.AddAsync(image);
        await _imageRepository.SaveChangeAsync();

        return new BaseResponse<string>("Image created successfully", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> UpdateAsync(Guid id, ImageUpdateDto dto)
    {
        var image = await _imageRepository.GetByIdAsync(id);
        if (image == null)
            return new BaseResponse<string>("Image not found", null, HttpStatusCode.NotFound);

        image.ImageUrl = dto.ImageUrl;
        image.IsMain = dto.IsMain;

        _imageRepository.Update(image);
        await _imageRepository.SaveChangeAsync();

        return new BaseResponse<string>("Image updated successfully", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var image = await _imageRepository.GetByIdAsync(id);
        if (image == null)
            return new BaseResponse<string>("Image not found", null, HttpStatusCode.NotFound);

        _imageRepository.Delete(image);
        await _imageRepository.SaveChangeAsync();

        return new BaseResponse<string>("Image deleted successfully", HttpStatusCode.OK);
    }
}
