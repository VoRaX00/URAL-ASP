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
        return _context.Cars.Where(car => (filters.Name == null || car.Name == filters.Name) &&
            (filters.Volume == null || filters.Volume == car.Volume) && (filters.Length == null || car.Length == filters.Length) 
            && (filters.Width == null || car.Width == filters.Width) && (filters.Capacity == null || car.Capacity == filters.Capacity) 
            && (filters.Height == null || car.Height == filters.Height) && (filters.WhereFrom == null || car.WhereFrom == filters.WhereFrom) 
            && (filters.WhereTo == null || car.WhereTo == filters.WhereTo) && (filters.ReadyFrom == null || car.ReadyFrom == filters.ReadyFrom)
            && (filters.ReadyTo == null || car.ReadyTo == filters.ReadyTo) && (filters.BodyTypes == null || car.BodyTypes.Count(type => 
                filters.BodyTypes.Count(name => type.Name == name) != 0) == filters.BodyTypes.Count) 
            && (filters.LoadingTypes == null || car.LoadingTypes.Count(type => 
                filters.LoadingTypes.Count(name => type.Name == name) != 0) == filters.LoadingTypes.Count)
        ).Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
    
    public override IQueryable<Car> GetAll()
    {
        return _context.Set<Car>().Include(x => x.BodyTypes).Include(x => x.LoadingTypes);
    }
}