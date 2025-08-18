using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ReviewDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ReviewGetDto> CreateAsync(ReviewCreateDto dto)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            Comment = dto.Comment,
            Rating = dto.Rating,
            AppUserId = dto.AppUserId,
            ProductId = dto.ProductId,
            CreatedAt = DateTime.Now
        };

        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveChangeAsync();

        return new ReviewGetDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }

    public async Task<ReviewGetDto> UpdateAsync(ReviewUpdateDto dto)
    {
        var review = await _reviewRepository.GetByIdAsync(dto.Id);
        if (review == null) throw new Exception("Review not found");

        review.Comment = dto.Comment;
        review.Rating = dto.Rating;

        _reviewRepository.Update(review);
        await _reviewRepository.SaveChangeAsync();

        return new ReviewGetDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        if (review == null) return false;

        _reviewRepository.Delete(review);
        await _reviewRepository.SaveChangeAsync();

        return true;
    }

    public async Task<ReviewGetDto> GetByIdAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        if (review == null) return null;

        return new ReviewGetDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }

    public async Task<List<ReviewGetDto>> GetReviewsByProductIdAsync(Guid productId)
    {
        var reviews = await _reviewRepository.GetReviewsByProductIdAsync(productId);
        return reviews.Select(r => new ReviewGetDto
        {
            Id = r.Id,
            Comment = r.Comment,
            Rating = r.Rating,
            CreatedAt = r.CreatedAt,
            UserName = r.AppUser?.UserName,
            ProductName = r.Product?.Name
        }).ToList();
    }
}