using System.Linq.Expressions;
using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
{
    private readonly IExpressionFilter<Cargo, CargoFilterParameter> filter;

    public CargoRepository(UralDbContext context, IExpressionFilter<Cargo, CargoFilterParameter> filter)
    {
        _context = context;
        this.filter = filter;
    }
    
    public IQueryable<Cargo> GetByName(string name)
    {
        return _context.Cargo.Where(cargo => cargo.Name == name);
    }

    public IQueryable<Cargo> GetByUserId(string id)
    {
        return _context.Cargo.Where(cargo => cargo.UserId == id);
    }

    public IQueryable<Cargo> GetByFilters(CargoFilterParameter cargoFilterParameter)
    {
        var filteringExpression = filter.GetFilteringExpression(cargoFilterParameter);
        return _context.Cargo.Where(filteringExpression);
    }
}