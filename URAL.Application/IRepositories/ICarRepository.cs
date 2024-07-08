using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>
{
    public IEnumerable<Cargo> GetByName(string name);
    public IEnumerable<Cargo> GetByUserId(ulong id);
}
