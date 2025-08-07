﻿using SevShop.Domain.Entities;
using System.Linq.Expressions;

namespace SevShop.Application.Abstracts.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetByFiltered(Expression<Func<T, bool>>? predicate = null,
          Expression<Func<T, object>>[]? include = null,
          bool isTracking = false);

    IQueryable<T> GetAll(bool isTracking = false);

    IQueryable<T> GetAllFiltered(Expression<Func<T, bool>>? predicate,
        Expression<Func<T, object>>[]? include = null,
        Expression<Func<T, object>>? orderby = null,
        bool isOrderByAsc = true,
        bool isTracking = false);

    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task SaveChangeAsync();
}
