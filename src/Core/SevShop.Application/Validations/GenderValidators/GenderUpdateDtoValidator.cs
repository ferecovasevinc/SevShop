using FluentValidation;
using SevShop.Application.DTOs.GenderDtos;

namespace SevShop.Application.Validations.GenderValidators;

public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
{
    public GenderUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(30).WithMessage("Name cannot exceed 30 characters");
    }
}
