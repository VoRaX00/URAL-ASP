﻿using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class CarService(IMapper mapper, ICarRepository repository) : ICarService
{
    public int PageSize { get; } = 4;

    public async Task<ulong> AddAsync(CarToAdd carToAdd, string userId)
    {
        var entity = mapper.Map<CarToAdd, Car>(carToAdd);
        entity.UserId = userId;
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(CarToDelete carToDelete)
    {
        var entity = mapper.Map<CarToDelete, Car>(carToDelete);
        repository.Delete(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<PaginatedList<CarToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<Car, CarToGet>(x));

        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public CarToGet GetById(ulong id)
    {
        return mapper.Map<Car, CarToGet>(repository.GetById(id));
    }

    public async Task<PaginatedList<CarToGet>> GetByNameAsync(string name, int pageNumber)
    {
        var result = repository.GetByName(name).Select(x => mapper.Map<Car, CarToGet>(x));

        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public async Task<PaginatedList<CarToGet>> GetByUserIdAsync(string id, int pageNumber)
    {
        var result = repository.GetByUserId(id).Select(x => mapper.Map<Car, CarToGet>(x));

        var cars = PaginatedList<CarToGet>.Create(result, pageNumber, PageSize);
        return await cars;
    }

    public async Task UpdateAsync(CarToUpdate carToUpdate)
    {
        var entity = repository.GetById(carToUpdate.Id);
        mapper.Map(carToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();
    }
}
