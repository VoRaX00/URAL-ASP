using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>
{
    public IQueryable<Cargo> GetByName(string name);
    public IQueryable<Cargo> GetByUserId(ulong id);
}
