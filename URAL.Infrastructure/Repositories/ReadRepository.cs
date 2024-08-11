using Microsoft.EntityFrameworkCore;
using URAL.Application.IRepositories;
using URAL.Domain.Common;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
{
    protected UralDbContext _context;
    public virtual IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public virtual TEntity? GetById(long id)
    {
        return _context.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
    }
}