using Microsoft.AspNetCore.Identity;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.RoleDtos;
using SevShop.Application.Shared;
using System.Net;
using System.Security.Claims;

namespace SevShop.Persistence.Services;

public class RoleService : IRoleService
{
    private RoleManager<IdentityRole<Guid>> _roleManager { get; }

    public RoleService(RoleManager<IdentityRole<Guid>> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<BaseResponse<string?>> CreateRole(RoleCreateDto dto)
    {
        var existingRole = await _roleManager.FindByNameAsync(dto.Name);
        if (existingRole is not null)
        {
            return new BaseResponse<string?>("Role already exists", HttpStatusCode.BadRequest);
        }

        var identityRole = new IdentityRole<Guid>
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            NormalizedName = dto.Name.ToUpper()
        };

        var result = await _roleManager.CreateAsync(identityRole);

        if (!result.Succeeded)
        {
            var errorMessages = string.Join(";", result.Errors.Select(e => e.Description));
            return new BaseResponse<string?>(errorMessages, HttpStatusCode.BadRequest);
        }

        foreach (var permission in dto.PermissionList.Distinct())
        {
            var claimResult = await _roleManager.AddClaimAsync(identityRole, new Claim("Permission", permission));
            if (!claimResult.Succeeded)
            {
                var error = string.Join(";", claimResult.Errors.Select(e => e.Description));
                return new BaseResponse<string?>($"Role created, but adding permission '{permission}' failed: {error}", HttpStatusCode.PartialContent);
            }
        }

        return new BaseResponse<string?>("Role created successfully", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<string?>> DeleteRole(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
        {
            return new BaseResponse<string?>("Role not found", HttpStatusCode.NotFound);
        }

        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded)
        {
            var errors = string.Join(";", result.Errors.Select(e => e.Description));
            return new BaseResponse<string?>($"Failed to delete role: {errors}", HttpStatusCode.BadRequest);
        }

        return new BaseResponse<string?>("Role deleted successfully", HttpStatusCode.OK);
    }
}

