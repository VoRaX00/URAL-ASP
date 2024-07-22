﻿using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.NotifyCar;
using URAL.Application.RequestModels.NotifyCargo;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class NotifyCarService(IMapper mapper, INotifyCarRepository repository) : INotifyCarService
{
    public int PageSize { get; } = 4;

    public async Task<ulong> AddAsync(NotifyCarToAdd notifyCarToAdd)
    {
        var entity = mapper.Map<NotifyCarToAdd, NotifyCar>(notifyCarToAdd);
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(NotifyCarToDelete notifyCarToDelete)
    {
        var entity = mapper.Map<NotifyCarToDelete, NotifyCar>(notifyCarToDelete);
        repository.Delete(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<PaginatedList<NotifyCarToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll();

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public NotifyCarToGet GetById(ulong id)
    {
        return mapper.Map<NotifyCar, NotifyCarToGet>(repository.GetById(id));
    }

    public async Task<PaginatedList<NotifyCarToGet>> GetUserMatchAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserMatch(userId);

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public async Task<PaginatedList<NotifyCarToGet>> GetUserNotificationsAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserNotifications(userId);

        var notifyCarPage = MapToPaginatedList(result, pageNumber);
        return await notifyCarPage;
    }

    public async Task<PaginatedList<NotifyCarToGet>> GetUserResponsesAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserResponses(userId);

        var notifyCarPage = MapToPaginatedList(result, pageNumber);
        return await notifyCarPage;
    }

    public async Task UpdateAsync(NotifyCarToUpdate notifyCarToUpdate)
    {
        var entity = repository.GetById(notifyCarToUpdate.Id);
        mapper.Map(notifyCarToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();
    }

    private async Task<PaginatedList<NotifyCarToGet>> MapToPaginatedList(IQueryable<NotifyCar> cargo, int pageNumber)
    {
        var notifyCargoToGets = cargo.Select(x => mapper.Map<NotifyCar, NotifyCarToGet>(x));

        return await PaginatedList<NotifyCarToGet>.Create(notifyCargoToGets, pageNumber, PageSize);
    }
}
