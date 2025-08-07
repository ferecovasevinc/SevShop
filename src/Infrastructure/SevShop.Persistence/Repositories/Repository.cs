using Microsoft.EntityFrameworkCore;
using SevShop.Application.Abstracts.Repositories;
using SevShop.Domain.Entities;
using System.Linq.Expressions;
using System.Linq;
using SevShop.Persistence.Contexts;

namespace SevShop.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private SevShopDbContext _context { get; }
    private DbSet<T> Table { get; }
    public Repository(SevShopDbContext context)
    {
        _context = context;
        Table = context.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public IQueryable<T> GetByFiltered(Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>[]? include = null,
        bool isTracking = false)
    {
        IQueryable<T> query = Table;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
        {
            foreach (var inculudeExpression in include)
                query = query.Include(inculudeExpression);
        }

        if (!isTracking)
            query = query.AsNoTracking();

        return query;
    }
    public IQueryable<T> GetAll(bool isTracking = false)
    {
        if (!isTracking)
            return Table.AsNoTracking();
        return Table;
    }


    public IQueryable<T> GetAllFiltered(Expression<Func<T, bool>>? predicate,
        Expression<Func<T, object>>[]? include = null,
        Expression<Func<T, object>>? orderby = null,
        bool isOrderByAsc = true,
        bool isTracking = false)
    {
        IQueryable<T> query = Table;

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
        {
            foreach (var inculudeExpression in include)
                query = query.Include(inculudeExpression);
        }

        if (orderby is not null)
        {
            if (isOrderByAsc)
                query = query.OrderBy(orderby);
            else
                query = query.OrderByDescending(orderby);
        }

        if (!isTracking)
            query = query.AsNoTracking();

        return query;
    }



    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

}
