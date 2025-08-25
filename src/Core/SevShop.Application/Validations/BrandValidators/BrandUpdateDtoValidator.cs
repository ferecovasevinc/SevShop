using FluentValidation;
using SevShop.Application.DTOs.BrandDtos;

namespace SevShop.Application.Validations.BrandValidators;

public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
{
    public BrandUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Brand name is required")
            .MaximumLength(50).WithMessage("Brand name must be at most 50 characters");
    }
}