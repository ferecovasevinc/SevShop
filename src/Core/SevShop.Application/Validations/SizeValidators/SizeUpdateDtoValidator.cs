using FluentValidation;
using SevShop.Application.DTOs.SizeDtos;

namespace SevShop.Application.Validations.SizeValidators;

public class SizeUpdateDtoValidator : AbstractValidator<SizeUpdateDto>
{
    public SizeUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dimension name cannot be empty")
            .MaximumLength(10).WithMessage("The dimension name can be a maximum of 10 characters");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0).WithMessage("SortOrder cannot be negative");
    }
}
