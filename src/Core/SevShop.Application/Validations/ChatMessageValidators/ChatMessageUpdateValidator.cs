using FluentValidation;
using SevShop.Application.DTOs.ChatMessageDtos;

namespace SevShop.Application.Validations.ChatMessageValidators;

public class ChatMessageUpdateValidator : AbstractValidator<ChatMessageUpdateDto>
{
    public ChatMessageUpdateValidator()
    {
        RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
    }
}
