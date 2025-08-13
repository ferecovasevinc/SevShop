using FluentValidation;
using SevShop.Application.DTOs.OrderDtos;

namespace SevShop.Application.Validations.OrderValidators;

public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
{
    public OrderCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Order name is required.")
            .MaximumLength(100).WithMessage("Order name cannot exceed 100 characters.");

        RuleFor(x => x.BuyerId)
            .NotEqual(Guid.Empty).WithMessage("Buyer ID must be provided.");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("Total price must be greater than 0.");

        RuleFor(x => x.TotalAmount)
            .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Shipping address is required.")
            .MaximumLength(200);

        RuleFor(x => x.ShippingCity)
            .NotEmpty().WithMessage("Shipping city is required.")
            .MaximumLength(100);

        RuleFor(x => x.ShippingPhone)
            .NotEmpty().WithMessage("Shipping phone is required.")
            .Matches(@"^\+?\d{7,15}$").WithMessage("Invalid phone number format.");
    }
}
