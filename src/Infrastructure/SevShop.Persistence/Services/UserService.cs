using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.UserDtos;
using SevShop.Application.Shared;
using SevShop.Application.Shared.Settings;
using SevShop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SevShop.Persistence.Services;

public class UserService : IUserService
{
    private UserManager<AppUser> _userManager { get; }
    private SignInManager<AppUser> _signInManager { get; }
    private JwtSettings _jwtSettings { get; }
    private RoleManager<IdentityRole<Guid>> _roleManager { get; }
    private IEmailService _emailService { get; }

    public UserService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IOptions<JwtSettings> jwtSettings,
        RoleManager<IdentityRole<Guid>> roleManager, IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
        _roleManager = roleManager;
        _emailService = emailService;
    }

    public async Task<BaseResponse<string>> Register(UserRegisterDto dto)
    {
        var existedEmail = await _userManager.FindByEmailAsync(dto.Email);
        if (existedEmail is not null)
        {
            return new BaseResponse<string>("This account already exist", HttpStatusCode.BadRequest);
        }

        AppUser newUser = new()
        {
            Email = dto.Email,
            FullName = dto.Fullname,
            UserName = dto.Email
        };

        IdentityResult identityResult = await _userManager.CreateAsync(newUser, dto.Password);
        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors;
            StringBuilder errorsMessage = new();
            foreach (var error in errors)
            {
                errorsMessage.Append(error.Description + ";");
            }

            return new BaseResponse<string>(errorsMessage.ToString(), HttpStatusCode.BadRequest);
        }

        var confirmEmailLink = await GetEmailConfirmLink(newUser);
        await _emailService.SendEmailAsync(new List<string> { newUser.Email }, "Email Confirmation", confirmEmailLink);

        return new BaseResponse<string>("Successfully created", HttpStatusCode.Created);
    }

    public async Task<BaseResponse<TokenResponse>> Login(UserLoginDto dto)
    {
        var existedUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existedUser is null)
        {
            return new("Email or password is wrong", HttpStatusCode.NotFound);
        }

        if (!existedUser.EmailConfirmed)
        {
            return new("Please confirm your email", HttpStatusCode.BadRequest);
        }

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, true, true);
        if (!signInResult.Succeeded)
        {
            return new("Email or password is wrong", null, HttpStatusCode.NotFound);
        }

        var tokenResponse = await GenerateTokenAsync(existedUser);
        return new("Token generated", tokenResponse, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var principal = GetPrincipalFromExpiredToken(request.AccessToken);
        var email = principal?.FindFirst(ClaimTypes.Email)?.Value;

        if (email is null)
            return new("Invalid access token", null, HttpStatusCode.Unauthorized);

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpireDate < DateTime.UtcNow)
        {
            return new("Invalid refresh token", null, HttpStatusCode.Unauthorized);
        }

        var newAccessToken = GenerateJwtToken(user.Email);
        var newRefreshToken = GenerateRefreshToken();
        var newRefreshTokenExpireDate = DateTime.UtcNow.AddDays(7);

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpireDate = newRefreshTokenExpireDate;

        await _userManager.UpdateAsync(user);

        TokenResponse response = new()
        {
            Token = newAccessToken,
            ExpireDate = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireDays),
            RefreshToken = newRefreshToken
        };

        return new("Token refreshed", response, HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> AddRole(UserAddRoleDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user is null)
            return new("User not found", HttpStatusCode.NotFound);

        List<string> roleNames = new();

        foreach (var roleId in dto.RolesId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role is null)
                return new($"Role with ID {roleId} not found", HttpStatusCode.NotFound);

            roleNames.Add(role.Name);
        }

        var result = await _userManager.AddToRolesAsync(user, roleNames);
        if (!result.Succeeded)
        {
            var errors = string.Join(";", result.Errors.Select(e => e.Description));
            return new($"Failed to add roles: {errors}", HttpStatusCode.BadRequest);
        }

        return new("Roles successfully assigned to the user", HttpStatusCode.OK);
    }

    public async Task<BaseResponse<string>> ConfirmEmail(Guid userId, string token)
    {
        var existedUser = await _userManager.FindByIdAsync(userId.ToString());
        if (existedUser is null)
        {
            return new("Email confirmation failed", HttpStatusCode.BadRequest);
        }

        var result = await _userManager.ConfirmEmailAsync(existedUser, token);
        if (!result.Succeeded)
        {
            return new("Email confirmation failed", HttpStatusCode.BadRequest);
        }
        return new("Email confirmed successfully", null, HttpStatusCode.OK);
    }

    private async Task<string> GetEmailConfirmLink(AppUser user)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var link = $"https://localhost:7248/api/Accounts/ConfirmEmail?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
        Console.WriteLine("Confirm Email link: " + token);
        return link;
    }

    private async Task<TokenResponse> GenerateTokenAsync(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };


        var roles = await _userManager.GetRolesAsync(user);
        foreach (var roleName in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role is not null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    if (roleClaim.Type == "Permission")
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireDays);

        var jwtToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpireDate = DateTime.UtcNow.AddDays(7);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireDate = refreshTokenExpireDate;

        await _userManager.UpdateAsync(user);

        return new TokenResponse
        {
            Token = token,
            ExpireDate = expires,
            RefreshToken = refreshToken
        };
    }

    private string GenerateJwtToken(string userEmail)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
        };



        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireDays),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

}
