using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Cargo;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class CargoService(IMapper mapper, ICargoRepository repository) : ICargoService
{
    public int PageSize { get; } = 4;

    public async Task<ulong> AddAsync(CargoToAdd cargoToAdd, ulong userId)
    {
        var entity = mapper.Map<CargoToAdd, Cargo>(cargoToAdd);
        entity.UserId = userId;
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(CargoToDelete cargoToDelete)
    {
        var entity = mapper.Map<CargoToDelete, Cargo>(cargoToDelete);
        repository.Delete(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<PaginatedList<CargoToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<Cargo, CargoToGet>(x));

        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);
        return await cargo;
    }

    public CargoToGet GetById(ulong id)
    {
        return mapper.Map<Cargo, CargoToGet>(repository.GetById(id));
    }

    public async Task<PaginatedList<CargoToGet>> GetByNameAsync(string name, int pageNumber)
    {
        var result = repository.GetByName(name).Select(x => mapper.Map<Cargo, CargoToGet>(x));

        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);
        return await cargo;
    }

    public async Task<PaginatedList<CargoToGet>> GetByUserIdAsync(ulong id, int pageNumber)
    {
        var result = repository.GetByUserId(id).Select(x => mapper.Map<Cargo, CargoToGet>(x));

        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);
        return await cargo;
    }

    public async Task UpdateAsync(CargoToUpdate cargoToUpdate)
    {
        var entity = repository.GetById(cargoToUpdate.Id);
        mapper.Map(cargoToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();
    }
}
