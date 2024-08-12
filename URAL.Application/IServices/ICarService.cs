using URAL.Application.Base;
using URAL.Application.Filters;
using URAL.Application.RequestModels.Car;
using URAL.Domain.Entities;

namespace URAL.Application.IServices;

public interface ICarService
{
    public Task<PaginatedList<CarToGet>> GetAllAsync(int pageNumber);
    public CarToGet? GetById(long id);
    Task<long> AddAsync(CarToAdd carToAdd, string userId);
    Task<bool> UpdateAsync(CarToUpdate carToUpdate);
    Task<bool> DeleteAsync(CarToDelete carToDelete);
    public Task<PaginatedList<CarToGet>> GetByFiltersAsync(CarFilter filters, int pageNumber);
    public Task<PaginatedList<CarToGet>> GetByUserIdAsync(string id, int pageNumber);
}
