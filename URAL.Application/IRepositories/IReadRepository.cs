using URAL.Domain.Common;

namespace URAL.Application.IRepositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity
{
    public IQueryable<TEntity> GetAll();
    public TEntity GetByID(ulong id);
}
