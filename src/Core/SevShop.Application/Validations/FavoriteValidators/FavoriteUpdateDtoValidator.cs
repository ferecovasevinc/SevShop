using FluentValidation;
using SevShop.Application.DTOs.FavoriteDtos;
namespace SevShop.Application.Validations.FavoriteValidators;

public class FavoriteUpdateDtoValidator : AbstractValidator<FavoriteUpdateDto>
{
    public FavoriteUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
    }
}
