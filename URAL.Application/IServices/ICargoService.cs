﻿using URAL.Application.Base;
using URAL.Application.RequestModels.Cargo;

namespace URAL.Application.IServices;

public interface ICargoService
{
    public Task<PaginatedList<CargoToGet>> GetAllAsync(int pageNumber);
    public CargoToGet? GetById(ulong id);
    Task<ulong> AddAsync(CargoToAdd cargoToAdd, string userId);
    Task UpdateAsync(CargoToUpdate cargoToUpdate);
    Task DeleteAsync(CargoToDelete cargoToDelete);
    public Task<PaginatedList<CargoToGet>> GetByNameAsync(string name, int pageNumber);
    public Task<PaginatedList<CargoToGet>> GetByUserIdAsync(string id, int pageNumber);
}
