using FluentValidation;
using SevShop.Application.DTOs.ProductDtos;

namespace SevShop.Application.Validations.ProductValidators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.StockCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.BrandId).NotEmpty();
        RuleFor(x => x.GenderId).NotEmpty();
    }
}
