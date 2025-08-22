using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.GenderDtos;
using SevShop.Domain.Entities;

namespace SevShop.Persistence.Services;

public class GenderService : IGenderService
{
    private readonly IGenderRepository _genderRepository;

    public GenderService(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public async Task<List<GenderGetDto>> GetAllAsync()
    {
        var genders = _genderRepository.GetAll(false).ToList();

        return genders.Select(x => new GenderGetDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }

    public async Task<GenderGetDto> GetByIdAsync(Guid id)
    {
        var gender = await _genderRepository.GetByIdAsync(id);
        if (gender == null) throw new Exception("Gender tapılmadı");

        return new GenderGetDto
        {
            Id = gender.Id,
            Name = gender.Name
        };
    }

    public async Task CreateAsync(GenderCreateDto dto)
    {
        var gender = new Gender
        {
            Name = dto.Name
        };

        await _genderRepository.AddAsync(gender);
        await _genderRepository.SaveChangeAsync();
    }

    public async Task UpdateAsync(GenderUpdateDto dto)
    {
        var gender = await _genderRepository.GetByIdAsync(dto.Id);
        if (gender == null) throw new Exception("Gender tapılmadı");

        gender.Name = dto.Name;

        _genderRepository.Update(gender);
        await _genderRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var gender = await _genderRepository.GetByIdAsync(id);
        if (gender == null) throw new Exception("Gender tapılmadı");

        _genderRepository.Delete(gender);
        await _genderRepository.SaveChangeAsync();
    }
}