namespace SevShop.Application.DTOs.FavoriteDtos;

public class FavoriteListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AppUserId { get; set; }
    public Guid ProductId { get; set; }
}
