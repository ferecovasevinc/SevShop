using SevShop.Application.DTOs.LanguageDtos;
using SevShop.Application.Shared;

namespace SevShop.Application.Abstracts.Services;

public interface ILanguageService
{
    Task<BaseResponse<List<LanguageGetDto>>> GetAllAsync();
    Task<BaseResponse<LanguageGetDto>> GetByIdAsync(Guid id);
    Task<BaseResponse<LanguageGetDto>> CreateAsync(LanguageCreateDto dto);
    Task<BaseResponse<LanguageGetDto>> UpdateAsync(Guid id, LanguageUpdateDto dto);
    Task<BaseResponse<bool>> DeleteAsync(Guid id);
}
