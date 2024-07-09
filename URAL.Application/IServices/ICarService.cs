using URAL.Application.Base;
using URAL.Application.RequestModels.Car;

namespace URAL.Application.IServices;

public interface ICarService
{
    public PaginatedList<CarToGet> GetAllAsync(int pageNumber);
    public CarToGet GetByID(ulong id);
    Task<ulong> AddAsync(CarToAdd carToAdd, ulong userId);
    Task AddRangeAsync(IEnumerable<CarToAdd> entities, ulong userId);
    void Update(CarToUpdate carToUpdate);
    void UpdateRange(IEnumerable<CarToUpdate> carToUpdate);
    void Delete(CarToDelete carToDelete);
    void DeleteRange(IEnumerable<CarToDelete> carToDelete);
    public Task<PaginatedList<CarToGet>> GetByNameAsync(string name, int pageNumber);
    public Task<PaginatedList<CarToGet>> GetByUserIdAsync(ulong id, int pageNumber);
}
