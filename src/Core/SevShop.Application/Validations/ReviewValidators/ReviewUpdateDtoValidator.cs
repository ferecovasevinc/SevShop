using FluentValidation;
using SevShop.Application.DTOs.ReviewDtos;

namespace SevShop.Application.Validations.ReviewValidators;

public class ReviewUpdateDtoValidator : AbstractValidator<ReviewUpdateDto>
{
    public ReviewUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("The opinion cannot be empty.")
            .MaximumLength(500);
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5);
    }
}
