using URAL.Application.Base;
using URAL.Application.Filter;
using URAL.Application.RequestModels.Cargo;

namespace URAL.Application.IServices;

public interface ICargoService
{
    public Task<PaginatedList<CargoToGet>> GetAllAsync(int pageNumber);
    public CargoToGet? GetById(ulong id);
    Task<ulong> AddAsync(CargoToAdd cargoToAdd, string userId);
    Task<bool> UpdateAsync(CargoToUpdate cargoToUpdate);
    Task<bool> DeleteAsync(CargoToDelete cargoToDelete);
    public Task<PaginatedList<CargoToGet>> GetByFiltersAsync(CargoFilter filters, int pageNumber);
    public Task<PaginatedList<CargoToGet>> GetByUserIdAsync(string id, int pageNumber);
}
