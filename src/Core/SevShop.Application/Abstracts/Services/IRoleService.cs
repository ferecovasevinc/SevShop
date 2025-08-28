using SevShop.Application.DTOs.RoleDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface IRoleService
{
    Task<BaseResponse<string?>> CreateRole(RoleCreateDto dto);
    Task<BaseResponse<string>> DeleteRole(string roleName);
}

