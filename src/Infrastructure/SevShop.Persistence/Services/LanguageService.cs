using SevShop.Application.Abstracts.Repositories;
using SevShop.Application.Abstracts.Services;
using SevShop.Application.DTOs.LanguageDtos;
using SevShop.Application.Shared;
using SevShop.Domain.Entities;
using System.Net;

namespace SevShop.Persistence.Services;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;

    public LanguageService(ILanguageRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<List<LanguageGetDto>>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        var result = entities.Select(l => new LanguageGetDto
        {
            Id = l.Id,
            Code = l.Code,
            Name = l.Name,
            IsActive = l.IsActive
        }).ToList();

        return new BaseResponse<List<LanguageGetDto>>(message: "Languages retrieved", data: result, statusCode: HttpStatusCode.OK);
    }

    public async Task<BaseResponse<LanguageGetDto>> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return new BaseResponse<LanguageGetDto>("Language not found", HttpStatusCode.NotFound);

        var dto = new LanguageGetDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            IsActive = entity.IsActive
        };

        return new BaseResponse<LanguageGetDto>(message: "Language found", data: dto, statusCode: HttpStatusCode.OK);
    }

    public async Task<BaseResponse<LanguageGetDto>> CreateAsync(LanguageCreateDto dto)
    {
        var entity = new Language
        {
            Code = dto.Code,
            Name = dto.Name,
            IsActive = true
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangeAsync();

        var result = new LanguageGetDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            IsActive = entity.IsActive
        };

        return new BaseResponse<LanguageGetDto>(message: "Language created", data: result, statusCode: HttpStatusCode.Created);
    }

    public async Task<BaseResponse<LanguageGetDto>> UpdateAsync(Guid id, LanguageUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id);
        if (entity == null)
            return new BaseResponse<LanguageGetDto>("Language not found", HttpStatusCode.NotFound);

        entity.Code = dto.Code;
        entity.Name = dto.Name;

        _repository.Update(entity);
        await _repository.SaveChangeAsync();

        var result = new LanguageGetDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            IsActive = entity.IsActive
        };

        return new BaseResponse<LanguageGetDto>(message: "Language updated", data: result, statusCode: HttpStatusCode.OK);
    }

    public async Task<BaseResponse<bool>> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return new BaseResponse<bool>("Language not found", HttpStatusCode.NotFound);

        _repository.Delete(entity);
        await _repository.SaveChangeAsync();

        return new BaseResponse<bool>(message: "Language deleted", data: true, statusCode: HttpStatusCode.OK);
    }
}