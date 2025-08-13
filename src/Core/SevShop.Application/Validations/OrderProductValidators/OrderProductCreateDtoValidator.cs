using FluentValidation;
using SevShop.Application.DTOs.OrderProductDtos;

namespace SevShop.Application.Validations.OrderProductValidators;

public class OrderProductCreateDtoValidator : AbstractValidator<OrderProductCreateDto>
{
    public OrderProductCreateDtoValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}