using FluentValidation;
using SevShop.Application.DTOs.GenderDtos;

namespace SevShop.Application.Validations.GenderValidators;

public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
{
    public GenderCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(30).WithMessage("Name cannot exceed 30 characters");
    }
}