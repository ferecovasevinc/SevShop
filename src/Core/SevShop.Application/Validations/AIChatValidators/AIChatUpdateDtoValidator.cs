using FluentValidation;
using SevShop.Application.DTOs.AIChatDtos;

namespace SevShop.Application.Validations.AIChatValidators;

public class AIChatUpdateDtoValidator : AbstractValidator<AIChatUpdateDto>
{
    public AIChatUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserMessage)
            .NotEmpty()
            .MaximumLength(1000);
        RuleFor(x => x.AIResponse)
            .NotEmpty()
            .MaximumLength(2000);
    }
}