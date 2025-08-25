using FluentValidation;
using SevShop.Application.DTOs.AIChatDtos;

namespace SevShop.Application.Validations.AIChatValidators;

public class AIChatCreateDtoValidator : AbstractValidator<AIChatCreateDto>
{
    public AIChatCreateDtoValidator()
    {
        RuleFor(x => x.AppUserId).NotEmpty();
        RuleFor(x => x.UserMessage)
            .NotEmpty()
            .MaximumLength(1000);
    }
}
