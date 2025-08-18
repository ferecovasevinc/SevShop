using SevShop.Application.DTOs.ReviewDtos;

namespace SevShop.Application.Abstracts.Services;

public interface IReviewService
{
    Task<ReviewGetDto> CreateAsync(ReviewCreateDto dto);
    Task<ReviewGetDto> UpdateAsync(ReviewUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<ReviewGetDto> GetByIdAsync(Guid id);
    Task<List<ReviewGetDto>> GetReviewsByProductIdAsync(Guid productId);
}