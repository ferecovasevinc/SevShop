using FluentValidation;
using SevShop.Application.DTOs.RoleDtos;

namespace SevShop.Application.Validations.RoleValidators;

public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto>
{
    public RoleCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required");

        RuleFor(x => x.PermissionList)
            .NotEmpty().WithMessage("At least one permission must be selected");
    }
}