using FluentValidation;
using SevShop.Application.DTOs.ChatMessageDtos;

namespace SevShop.Application.Validations.ChatMessageValidators;

public class ChatMessageCreateValidator : AbstractValidator<ChatMessageCreateDto>
{
    public ChatMessageCreateValidator()
    {
        RuleFor(x => x.SenderId).NotEmpty();
        RuleFor(x => x.ReceiverId).NotEmpty();
        RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
    }
}