using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICargoRepository : IBaseRepository<Cargo>
{
    public IEnumerable<Cargo> GetByName(string name);
    public IEnumerable<Cargo> GetByUserId(ulong id);
}
