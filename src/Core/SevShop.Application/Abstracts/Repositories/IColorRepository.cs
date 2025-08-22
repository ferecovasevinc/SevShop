﻿using SevShop.Domain.Entities;

namespace SevShop.Application.Abstracts.Repositories;

public interface IColorRepository
{
    Task<List<Color>> GetAllAsync();
    Task<Color> GetByIdAsync(Guid id);
    Task AddAsync(Color color);
    Task UpdateAsync(Color color);
    Task DeleteAsync(Color color);
}
