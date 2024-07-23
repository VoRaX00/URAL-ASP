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
    
    public IQueryable<Car> GetByName(string name)
    {
        return _context.Cars.Where(car => car.Name == name);
    }

    public IQueryable<Car> GetByUserId(string id)
    {
        return _context.Cars.Where(car => car.UserId == id);
    }
}