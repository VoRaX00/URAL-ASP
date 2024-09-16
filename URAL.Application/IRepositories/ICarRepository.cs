using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>
{
    public IQueryable<Car> GetByName(string name);
    public IQueryable<Car> GetByUserId(string id);
    public IQueryable<Car> GetByFilters(CarFilterParameter filterParameter);
}
