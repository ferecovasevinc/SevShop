using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.FavoriteDtos;
using SevShop.Application.Shared.Extensions;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoritesController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    // GET: /api/favourites
    [HttpGet]
    public async Task<IActionResult> GetMyFavorites()
    {
        var userId = User.GetUserId();
        var response = await _favoriteService.GetByUserIdAsync(userId);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: /api/favourites/{productId}
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToFavorite(Guid productId)
    {
        var userId = User.GetUserId();
        var dto = new FavoriteCreateDto
        {
            Name = "Favorite",
            AppUserId = userId,
            ProductId = productId
        };
        var response = await _favoriteService.CreateAsync(dto);
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: /api/favourites/{productId}
    [HttpDelete("{productId}")]
    public async Task<IActionResult> RemoveFromFavorite(Guid productId)
    {
        var userId = User.GetUserId();
        var userFavorites = await _favoriteService.GetByUserIdAsync(userId);
        var fav = userFavorites.Data?.FirstOrDefault(f => f.ProductId == productId);
        if (fav == null)
            return NotFound("Favorite not found");

        var response = await _favoriteService.DeleteAsync(fav.Id);
        return StatusCode((int)response.StatusCode, response);
    }
}
