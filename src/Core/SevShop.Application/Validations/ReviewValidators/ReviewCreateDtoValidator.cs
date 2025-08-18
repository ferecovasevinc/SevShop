using FluentValidation;
using SevShop.Application.DTOs.ReviewDtos;

namespace SevShop.Application.Validations.ReviewValidators;

public class ReviewCreateDtoValidator : AbstractValidator<ReviewCreateDto>
{
    public ReviewCreateDtoValidator()
    {
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("The opinion cannot be empty.")
            .MaximumLength(500).WithMessage("The review cannot exceed 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("The rating should be between 1-5.");

        RuleFor(x => x.AppUserId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}