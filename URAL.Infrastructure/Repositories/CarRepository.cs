using Microsoft.EntityFrameworkCore;
using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    private readonly IExpressionFilter<Car, CarFilterParameter> filter;

    public CarRepository(UralDbContext context, IExpressionFilter<Car, CarFilterParameter> filter)
    {
        _context = context;
        this.filter = filter;
    }

    public override async Task<Car> AddAsync(Car entity)
    {
        var newEntity = await base.AddAsync(entity);

        foreach (var item in newEntity.BodyTypes)
            _context.Entry(item).State = EntityState.Unchanged;

        foreach (var item in newEntity.LoadingTypes)
            _context.Entry(item).State = EntityState.Unchanged;

        return newEntity;
    }

    public IQueryable<Car> GetByName(string name)
    {
        return _context.Cars.Where(car => car.Name == name).Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }

    public IQueryable<Car> GetByUserId(string id)
    {
        return _context.Cars.Where(car => car.UserId == id).Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }

    public override Car? GetById(long id)
    {
        return _context.Cars.Where(car => car.Id == id).Include(x => x.BodyTypes).Include(x => x.LoadingTypes).FirstOrDefault();
    }

    public IQueryable<Car> GetByFilters(CarFilterParameter carFilterParameter)
    {
        var filteringExpression = filter.GetFilteringExpression(carFilterParameter);
        return _context.Cars.Where(filteringExpression).Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
    
    public override IQueryable<Car> GetAll()
    {
        return _context.Set<Car>().Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
}