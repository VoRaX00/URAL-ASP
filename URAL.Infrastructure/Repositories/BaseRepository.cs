using Microsoft.EntityFrameworkCore;
using URAL.Application.IRepositories;
using URAL.Domain.Common;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class BaseRepository<TEntity> : ReadRepository<TEntity>, IBaseRepository<TEntity> where TEntity : BaseEntity
{    
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
}