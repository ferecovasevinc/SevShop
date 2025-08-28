namespace SevShop.Application.DTOs.RoleDtos;

public class AddRoleDto
{
    public Guid AppUserId { get; set; }
    public string RoleName { get; set; } = null!;
}
