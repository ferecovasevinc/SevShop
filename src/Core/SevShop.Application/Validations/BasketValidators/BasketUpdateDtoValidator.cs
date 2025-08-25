using FluentValidation;
using SevShop.Application.DTOs.BaketDtos;

namespace SevShop.Application.Validations.BasketValidators;

public class BasketUpdateDtoValidator : AbstractValidator<BasketUpdateDto>
{
    public BasketUpdateDtoValidator()
    {
        RuleFor(x => x.BuyerId).NotEmpty().WithMessage("BuyerId cannot be empty");
    }
}
