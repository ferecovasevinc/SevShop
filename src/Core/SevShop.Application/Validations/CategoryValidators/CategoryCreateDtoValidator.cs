using FluentValidation;
using SevShop.Application.DTOs.CategoryDtos;

namespace SevShop.Application.Validations.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name can not be null.")
            .MinimumLength(3).WithMessage("Name should be minimum 3 characters.");
    }
}

