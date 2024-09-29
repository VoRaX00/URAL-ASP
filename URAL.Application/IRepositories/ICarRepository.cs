using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>, IFilterableRepository<Car>
{
    public IQueryable<Car> GetByName(string name);
    public IQueryable<Car> GetByUserId(string id);
}
