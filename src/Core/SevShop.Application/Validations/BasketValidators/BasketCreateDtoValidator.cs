using FluentValidation;
using SevShop.Application.DTOs.BaketDtos;

namespace SevShop.Application.Validations.BasketValidators;

public class BasketCreateDtoValidator : AbstractValidator<BasketCreateDto>
{
    public BasketCreateDtoValidator()
    {
        RuleFor(x => x.BuyerId).NotEmpty().WithMessage("BuyerId cannot be empty");
    }
}
