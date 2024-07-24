using Microsoft.EntityFrameworkCore;
using URAL.Application.IRepositories;
using URAL.Domain.Common;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class BaseRepository<TEntity> : ReadRepository<TEntity>, IBaseRepository<TEntity> where TEntity : BaseEntity
{    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
}