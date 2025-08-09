using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.FavoriteDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Net;

namespace SevShop.Persistence.Services;

public class FavoriteService : IFavoriteService
{
    private IFavoriteRepository _favoriteRepository { get; }

    public FavoriteService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<BaseResponse<List<FavoriteListDto>>> GetAllAsync()
    {
        var favorites = await _favoriteRepository.GetAll().ToListAsync();

        var dto = favorites.Select(f => new FavoriteListDto
        {
            Id = f.Id,
            Name = f.Name,
            AppUserId = f.AppUserId,
            ProductId = f.ProductId
        }).ToList();

        return new("List fetched", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<List<FavoriteListDto>>> GetByUserIdAsync(Guid userId)
    {
        var data = await _favoriteRepository.GetFavoritesByUserIdAsync(userId);
        var dto = data.Select(f => new FavoriteListDto
        {
            Id = f.Id,
            Name = f.Name,
            AppUserId = f.AppUserId,
            ProductId = f.ProductId
        }).ToList();

        return new("User's favorites", dto, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> CreateAsync(FavoriteCreateDto dto)
    {
        var favorite = new Favorite
        {
            Name = dto.Name,
            AppUserId = dto.AppUserId,
            ProductId = dto.ProductId
        };

        await _favoriteRepository.AddAsync(favorite);
        await _favoriteRepository.SaveChangeAsync();
        return new("Created successfully", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string>> UpdateAsync(Guid id, FavoriteUpdateDto dto)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(id);
        if (favorite == null)
            return new BaseResponse<string>("Favorite not found", null, HttpStatusCode.NotFound);

        favorite.Name = dto.Name;

        _favoriteRepository.Update(favorite);
        await _favoriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Updated successfully", null, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> DeleteAsync(Guid id)
    {
        var favorite = await _favoriteRepository.GetByIdAsync(id);
        if (favorite == null)
            return new BaseResponse<string>("Favorite not found", null, HttpStatusCode.NotFound);

        _favoriteRepository.Delete(favorite);
        await _favoriteRepository.SaveChangeAsync();

        return new BaseResponse<string>("Deleted successfully", null, HttpStatusCode.OK);
    }
}
