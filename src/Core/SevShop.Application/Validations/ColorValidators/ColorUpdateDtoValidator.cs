using FluentValidation;
using SevShop.Application.DTOs.ColorDtos;

namespace SevShop.Application.Validations.ColorValidators;

public class ColorUpdateDtoValidator : AbstractValidator<ColorUpdateDto>
{
    public ColorUpdateDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.HexCode).NotEmpty().MaximumLength(7);
    }
}
