using FluentValidation;
using SevShop.Application.DTOs.LanguageDtos;

namespace SevShop.Application.Validations.LanguageValidators;

public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
{
    public LanguageCreateDtoValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(5);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50);
    }
}
