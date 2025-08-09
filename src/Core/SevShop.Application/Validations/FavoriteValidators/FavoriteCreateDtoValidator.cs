using FluentValidation;
using SevShop.Application.DTOs.FavoriteDtos;
namespace SevShop.Application.Validations.FavoriteValidators;

public class FavoriteCreateDtoValidator : AbstractValidator<FavoriteCreateDto>
{
    public FavoriteCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("AppUserId is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");
    }
}