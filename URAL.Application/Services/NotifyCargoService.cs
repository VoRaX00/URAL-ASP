using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.NotifyCargo;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class NotifyCargoService(IMapper mapper, INotifyCargoRepository repository) : INotifyCargoService
{
    public int PageSize { get; } = 4;

    public async Task<ulong> AddAsync(NotifyCargoToAdd notifyCargoToAdd)
    {
        var entity = mapper.Map<NotifyCargoToAdd, NotifyCargo>(notifyCargoToAdd);
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(NotifyCargoToDelete notifyCargoToDelete)
    {
        var entity = repository.GetById(notifyCargoToDelete.Id);

        if (entity is null)
            return false;

        repository.Delete(entity);
        await repository.SaveChangesAsync();

        return true;
    }

    public async Task<PaginatedList<NotifyCargoToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll();

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public NotifyCargoToGet? GetById(ulong id)
    {
        var result = repository.GetById(id);

        if (result == null)
            return null;

        return mapper.Map<NotifyCargo, NotifyCargoToGet>(result);
    }

    public async Task<PaginatedList<NotifyCargoToGet>> GetUserMatchAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserMatch(userId);

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public async Task<PaginatedList<NotifyCargoToGet>> GetUserNotificationsAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserNotifications(userId);

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public async Task<PaginatedList<NotifyCargoToGet>> GetUserResponsesAsync(string userId, int pageNumber)
    {
        var result = repository.GetUserResponses(userId);

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public async Task<bool> UpdateAsync(NotifyCargoToUpdate notifyCargoToUpdate)
    {
        var entity = repository.GetById(notifyCargoToUpdate.Id);

        if (entity is null)
            return false;

        mapper.Map(notifyCargoToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();

        return true;
    }

    private async Task<PaginatedList<NotifyCargoToGet>> MapToPaginatedList(IQueryable<NotifyCargo> cargo, int pageNumber)
    {
        var notifyCargoToGets = cargo.Select(x => mapper.Map<NotifyCargo, NotifyCargoToGet>(x));

        return await PaginatedList<NotifyCargoToGet>.Create(notifyCargoToGets, pageNumber, PageSize);
    }
}
