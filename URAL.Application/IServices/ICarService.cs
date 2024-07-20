using URAL.Application.Base;
using URAL.Application.RequestModels.Car;

namespace URAL.Application.IServices;

public interface ICarService
{
    public Task<PaginatedList<CarToGet>> GetAllAsync(int pageNumber);
    public CarToGet GetById(ulong id);
    Task<ulong> AddAsync(CarToAdd carToAdd, ulong userId);
    Task UpdateAsync(CarToUpdate carToUpdate);
    Task DeleteAsync(CarToDelete carToDelete);
    public Task<PaginatedList<CarToGet>> GetByNameAsync(string name, int pageNumber);
    public Task<PaginatedList<CarToGet>> GetByUserIdAsync(ulong id, int pageNumber);
}
