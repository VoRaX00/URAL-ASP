using URAL.Domain.Common;

namespace URAL.Application.IRepositories;

public interface IBaseRepository<TEntity> : IRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
{
}
