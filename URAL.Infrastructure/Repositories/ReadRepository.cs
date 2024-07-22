using URAL.Application.IRepositories;
using URAL.Domain.Common;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
{
    protected UralDbContext _context;
    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public TEntity GetById(ulong id)
    {
        return _context.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
    }
}