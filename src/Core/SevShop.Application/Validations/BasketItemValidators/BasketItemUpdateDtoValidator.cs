using FluentValidation;
using SevShop.Application.DTOs.BasketItemDtos;

namespace SevShop.Application.Validations.BasketItemValidators;

public class BasketItemUpdateDtoValidator : AbstractValidator<BasketItemUpdateDto>
{
    public BasketItemUpdateDtoValidator()
    {
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    }
}