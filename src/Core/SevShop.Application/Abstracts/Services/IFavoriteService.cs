using SevShop.Application.DTOs.FavoriteDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface IFavoriteService
{
    Task<BaseResponse<List<FavoriteListDto>>> GetAllAsync();
    Task<BaseResponse<string>> CreateAsync(FavoriteCreateDto dto);
    Task<BaseResponse<List<FavoriteListDto>>> GetByUserIdAsync(Guid userId);
    Task<BaseResponse<string>> UpdateAsync(Guid id, FavoriteUpdateDto dto);
    Task<BaseResponse<string>> DeleteAsync(Guid id);
}
