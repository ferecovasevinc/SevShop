using FluentValidation;
using SevShop.Application.DTOs.LanguageDtos;

namespace SevShop.Application.Validations.LanguageValidators;

public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
{
    public LanguageUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(x => x.Code).NotEmpty().MaximumLength(5);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}