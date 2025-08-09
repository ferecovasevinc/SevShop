namespace SevShop.Application.DTOs.FavoriteDtos;

public class FavoriteCreateDto
{
    public string Name { get; set; }
    public Guid AppUserId { get; set; }
    public Guid ProductId { get; set; }
}
