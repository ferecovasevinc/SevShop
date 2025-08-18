using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ReviewDtos;
using SevShop.Application.Shared;

namespace SevShop.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Authorize(Policy = Permissions.Review.Create)]
        public async Task<IActionResult> Create([FromBody] ReviewCreateDto dto)
        {
            var result = await _reviewService.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = Permissions.Review.Update)]
        public async Task<IActionResult> Update([FromBody] ReviewUpdateDto dto)
        {
            var result = await _reviewService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Permissions.Review.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _reviewService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = Permissions.Review.GetByProductId)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByProductId(Guid productId)
        {
            var result = await _reviewService.GetReviewsByProductIdAsync(productId);
            return Ok(result);
        }
    }
