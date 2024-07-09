using URAL.Application.Base;
using URAL.Application.RequestModels.Cargo;

namespace URAL.Application.IServices;

public interface ICargoService
{
    public PaginatedList<CargoToGet> GetAllAsync(int pageNumber);
    public CargoToGet GetByID(ulong id);
    Task<ulong> AddAsync(CargoToAdd cargoToAdd, ulong userId);
    Task AddRangeAsync(IEnumerable<CargoToAdd> entities, ulong userId);
    void Update(CargoToUpdate cargoToUpdate);
    void UpdateRange(IEnumerable<CargoToUpdate> cargoToUpdate);
    void Delete(CargoToDelete cargoToDelete);
    void DeleteRange(IEnumerable<CargoToDelete> cargoToDelete);
    public Task<PaginatedList<CargoToGet>> GetByNameAsync(string name, int pageNumber);
    public Task<PaginatedList<CargoToGet>> GetByUserIdAsync(ulong id, int pageNumber);
}
