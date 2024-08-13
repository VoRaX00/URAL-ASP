using System.Linq.Expressions;
using URAL.Application.Filters;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
{
    public CargoRepository(UralDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Cargo> GetByName(string name)
    {
        return _context.Cargo.Where(cargo => cargo.Name == name);
    }

    public IQueryable<Cargo> GetByUserId(string id)
    {
        return _context.Cargo.Where(cargo => cargo.UserId == id);
    }

    public IQueryable<Cargo> GetByFilters(IExpressionFilter<Cargo> filter)
    {
        var a = filter.GetFilteringExpression();
        return _context.Cargo.Where(a);
    }
}