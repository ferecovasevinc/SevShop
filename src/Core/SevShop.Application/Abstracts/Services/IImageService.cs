using SevShop.Application.Shared;
using SevShop.Application.DTOs.ImageDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IImageService
{
    Task<BaseResponse<List<ImageListDto>>> GetAllAsync();
    Task<BaseResponse<ImageListDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<string>> CreateAsync(ImageCreateDto dto);
    Task<BaseResponse<string>> UpdateAsync(Guid id, ImageUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
}