using System.Linq.Expressions;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface IFilterableRepository<TEntity>
{
    public IQueryable<TEntity> GetByFilters(Expression<Func<TEntity, bool>> filteringExpression);
}
