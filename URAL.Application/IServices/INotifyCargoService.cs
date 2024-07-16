using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCargo;

namespace URAL.Application.IServices;

public interface INotifyCargoService
{
    public Task<PaginatedList<NotifyCargoToGet>> GetAllAsync(int pageNumber);
    public NotifyCargoToGet GetByID(ulong id);
    Task<ulong> AddAsync(NotifyCargoToAdd notifyCargoToAdd);
    Task UpdateAsync(NotifyCargoToUpdate notifyCargoToUpdate);
    Task DeleteAsync(NotifyCargoToDelete notifyCargoToDelete);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserMatchAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserNotificationsAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserResponsesAsync(ulong userId, int pageNumber);
}
