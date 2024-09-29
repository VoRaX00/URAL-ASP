using System.Linq.Expressions;
using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICargoRepository : IBaseRepository<Cargo>, IFilterableRepository<Cargo>
{
    public IQueryable<Cargo> GetByName(string name);
    public IQueryable<Cargo> GetByUserId(string id);
}
