using FluentValidation;
using SevShop.Application.DTOs.OrderProductDtos;

namespace SevShop.Application.Validations.OrderProductValidators;

public class OrderProductUpdateDtoValidator : AbstractValidator<OrderProductUpdateDto>
{
    public OrderProductUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
