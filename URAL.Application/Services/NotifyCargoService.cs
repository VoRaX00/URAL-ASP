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

    public async Task DeleteAsync(NotifyCargoToDelete notifyCargoToDelete)
    {
        var entity = mapper.Map<NotifyCargoToDelete, NotifyCargo>(notifyCargoToDelete);
        repository.Delete(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<PaginatedList<NotifyCargoToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll();

        var notifyCargoPage = MapToPaginatedList(result, pageNumber);
        return await notifyCargoPage;
    }

    public NotifyCargoToGet GetById(ulong id)
    {
        return mapper.Map<NotifyCargo, NotifyCargoToGet>(repository.GetById(id));
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

    public async Task UpdateAsync(NotifyCargoToUpdate notifyCargoToUpdate)
    {
        var entity = repository.GetById(notifyCargoToUpdate.Id);
        mapper.Map(notifyCargoToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();
    }

    private async Task<PaginatedList<NotifyCargoToGet>> MapToPaginatedList(IQueryable<NotifyCargo> cargo, int pageNumber)
    {
        var notifyCargoToGets = cargo.Select(x => mapper.Map<NotifyCargo, NotifyCargoToGet>(x));

        return await PaginatedList<NotifyCargoToGet>.Create(notifyCargoToGets, pageNumber, PageSize);
    }
}
