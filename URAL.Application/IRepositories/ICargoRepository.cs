using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface ICargoRepository : IBaseRepository<Cargo>
{
    public IQueryable<Cargo> GetByName(string name);
    public IQueryable<Cargo> GetByUserId(string id);
}
