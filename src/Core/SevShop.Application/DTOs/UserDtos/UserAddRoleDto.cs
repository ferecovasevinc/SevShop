namespace SevShop.Application.DTOs.UserDtos;

public class UserAddRoleDto
{
    public string UserId { get; set; } = null!;
    public List<string> RolesId { get; set; } = new();
}
