using Microsoft.EntityFrameworkCore;
using URAL.Application.Filter;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(UralDbContext context)
    {
        _context = context;
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

    public override Car? GetById(ulong id)
    {
        return _context.Cars.Where(car => car.Id == id).Include(x => x.BodyTypes).Include(x => x.LoadingTypes).FirstOrDefault();
    }

    public IQueryable<Car> GetByFilters(CarFilter filters)
    {
        return _context.Cars.Where(car => (filters.name == null || car.Name == filters.name) &&
            (filters.volume == null || filters.volume == car.Volume) && (filters.length == null || car.Length == filters.length) 
            && (filters.width == null || car.Width == filters.width) && (filters.capacity == null || car.Capacity == filters.capacity) 
            && (filters.height == null || car.Height == filters.height) && (filters.whereFrom == null || car.WhereFrom == filters.whereFrom) 
            && (filters.whereTo == null || car.WhereTo == filters.whereTo) && (filters.readyFrom == null || car.ReadyFrom == filters.readyFrom)
            && (filters.readyTo == null || car.ReadyTo == filters.readyTo) && (filters.bodyTypes == null || car.BodyTypes.Count(type => 
                filters.bodyTypes.Count(name => type.Name == name) != 0) == filters.bodyTypes.Count) 
            && (filters.loadingTypes == null || car.LoadingTypes.Count(type => 
                filters.loadingTypes.Count(name => type.Name == name) != 0) == filters.loadingTypes.Count)
        ).Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
    
    public override IQueryable<Car> GetAll()
    {
        return _context.Set<Car>().Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
}