using FluentValidation;
using SevShop.Application.DTOs.ImageDtos;

namespace SevShop.Application.Validations.ImageValidators;

public class ImageUpdateDtoValidator : AbstractValidator<ImageUpdateDto>
{
    public ImageUpdateDtoValidator()
    {
        RuleFor(i => i.ImageUrl)
            .NotEmpty().WithMessage("Image URL must not be empty.")
            .MaximumLength(500).WithMessage("Image URL is too long. Maximum 500 characters allowed.");
    }
}
