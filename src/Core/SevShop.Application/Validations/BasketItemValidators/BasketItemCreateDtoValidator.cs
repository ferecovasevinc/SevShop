using FluentValidation;
using SevShop.Application.DTOs.BasketItemDtos;

namespace SevShop.Application.Validations.BasketItemValidators;

public class BasketItemCreateDtoValidator : AbstractValidator<BasketItemCreateDto>
{
    public BasketItemCreateDtoValidator()
    {
        RuleFor(x => x.BasketId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
    }
}