﻿namespace SevShop.Application.DTOs.RoleDtos;

public class RoleCreateDto
{
    public string Name { get; set; } = null!;
    public List<string> PermissionList { get; set; }
}
