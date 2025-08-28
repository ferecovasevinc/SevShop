using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.RoleDtos;
using SevShop.Application.Shared.Helpers;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private IRoleService _roleService { get; }
    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }


    [HttpGet("permissions")]
    public IActionResult GetAllPermissions()
    {
        var permissions = PermissionHelper.GetAllPermissions();
        return Ok(permissions);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleCreateDto dto)
    {
        var result = await _roleService.CreateRole(dto);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("{roleName}")]
    public async Task<IActionResult> Delete(string roleName)
    {
        var result = await _roleService.DeleteRole(roleName);
        return StatusCode((int)result.StatusCode, result);
    }
}
