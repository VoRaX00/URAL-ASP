﻿using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Cargo;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class CargoService(IMapper mapper, ICargoRepository repository, IExpressionFilter<Cargo, CargoFilterParameter> filter) : ICargoService
{
    public int PageSize { get; } = 4;

    public async Task<long> AddAsync(CargoToAdd cargoToAdd, string userId)
    {
        var entity = mapper.Map<CargoToAdd, Cargo>(cargoToAdd);
        entity.UserId = userId;
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(CargoToDelete cargoToDelete)
    {
        var entity = repository.GetById(cargoToDelete.Id);

        if (entity is null)
            return false;

        repository.Delete(entity);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<PaginatedList<CargoToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<Cargo, CargoToGet>(x));

        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);

        return await cargo;
    }

    public CargoToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;

        return mapper.Map<Cargo, CargoToGet>(entity);
    }

    public async Task<PaginatedList<CargoToGet>> GetByFiltersAsync(CargoFilterParameter cargoFilterParameter, int pageNumber)
    {
        var expression = filter.GetFilteringExpression(cargoFilterParameter);
        var result = repository.GetByFilters(expression).Select(x => mapper.Map<Cargo, CargoToGet>(x));
        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);

        return await cargo;
    }

    public async Task<PaginatedList<CargoToGet>> GetByUserIdAsync(string id, int pageNumber)
    {
        var result = repository.GetByUserId(id).Select(x => mapper.Map<Cargo, CargoToGet>(x));

        var cargo = PaginatedList<CargoToGet>.Create(result, pageNumber, PageSize);

        return await cargo;
    }

    public async Task<bool> UpdateAsync(CargoToUpdate cargoToUpdate)
    {
        var entity = repository.GetById(cargoToUpdate.Id);

        if (entity is null) 
            return false;

        mapper.Map(cargoToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();

        return true;
    }
}
