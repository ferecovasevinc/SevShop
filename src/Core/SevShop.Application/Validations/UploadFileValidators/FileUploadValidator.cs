using FluentValidation;
using SevShop.Application.DTOs.FileUploadDtos;

namespace SevShop.Application.Validations.UploadFileValidators;

public class FileUploadValidator : AbstractValidator<FileUploadDto>
{

    public FileUploadValidator()
    {
        RuleFor(x => x.File)
        .NotEmpty()
            .WithMessage("You have to upload at least 1 fille")
        .Must(file => file.Length > 0).WithMessage("File cannot be empty")
        .Must(file => file.Length <= 3L * 1024 * 1024 * 1024)  // 3 GB limit
            .WithMessage("The file size cannot exceed 3GB");
    }

}
