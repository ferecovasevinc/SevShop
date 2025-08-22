using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.ColorDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class ColorService : IColorService
{
    private readonly IColorRepository _colorRepository;

    public ColorService(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task<List<ColorGetDto>> GetAllAsync()
    {
        var colors = await _colorRepository.GetAllAsync();
        return colors.Select(c => new ColorGetDto
        {
            Id = c.Id,
            Name = c.Name,
            HexCode = c.HexCode,
            IsDark = c.IsDark
        }).ToList();
    }

    public async Task<ColorGetDto> GetByIdAsync(Guid id)
    {
        var c = await _colorRepository.GetByIdAsync(id);
        if (c == null) return null;

        return new ColorGetDto
        {
            Id = c.Id,
            Name = c.Name,
            HexCode = c.HexCode,
            IsDark = c.IsDark
        };
    }

    public async Task<ColorGetDto> CreateAsync(ColorCreateDto dto)
    {
        var color = new Color
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            HexCode = dto.HexCode,
            IsDark = dto.IsDark
        };

        await _colorRepository.AddAsync(color);

        return new ColorGetDto
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            IsDark = color.IsDark
        };
    }

    public async Task<ColorGetDto> UpdateAsync(Guid id, ColorUpdateDto dto)
    {
        var color = await _colorRepository.GetByIdAsync(id);
        if (color == null) return null;

        color.Name = dto.Name;
        color.HexCode = dto.HexCode;
        color.IsDark = dto.IsDark;

        await _colorRepository.UpdateAsync(color);

        return new ColorGetDto
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode,
            IsDark = color.IsDark
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var color = await _colorRepository.GetByIdAsync(id);
        if (color == null) return false;

        await _colorRepository.DeleteAsync(color);
        return true;
    }
}
