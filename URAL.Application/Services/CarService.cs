using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.Filters;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class CarService(IMapper mapper, ICarRepository repository) : ICarService
{
    public int PageSize { get; } = 4;

    public async Task<long> AddAsync(CarToAdd carToAdd, string userId)
    {
        var entity = mapper.Map<CarToAdd, Car>(carToAdd);
        entity.UserId = userId;
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(CarToDelete carToDelete)
    {
        var entity = repository.GetById(carToDelete.Id);

        if (entity is null)
            return false;

        repository.Delete(entity);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<PaginatedList<CarToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<Car, CarToGet>(x));

        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public CarToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;

        return mapper.Map<Car, CarToGet>(entity);
    }

    public async Task<PaginatedList<CarToGet>> GetByUserIdAsync(string id, int pageNumber)
    {
        var result = repository.GetByUserId(id).Select(x => mapper.Map<Car, CarToGet>(x));
        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public async Task<PaginatedList<CarToGet>> GetByFiltersAsync(IExpressionFilter<Car> filters, int pageNumber)
    {
        var result = repository.GetByFilters(filters).Select(x => mapper.Map<Car, CarToGet>(x));
        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public async Task<bool> UpdateAsync(CarToUpdate carToUpdate)
    {
        var entity = repository.GetById(carToUpdate.Id);

        if (entity is null) 
            return false;

        mapper.Map(carToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();

        return true;
    }
}
