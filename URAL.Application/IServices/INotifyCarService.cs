using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCar;

namespace URAL.Application.IServices;

public interface INotifyCarService
{
    public Task<PaginatedList<NotifyCarToGet>> GetAllAsync(int pageNumber);
    public NotifyCarToGet GetByID(ulong id);
    Task<ulong> AddAsync(NotifyCarToAdd notifyCarToAdd);
    Task UpdateAsync(NotifyCarToUpdate notifyCarToUpdate);
    Task DeleteAsync(NotifyCarToDelete notifyCarToDelete);
    public Task<PaginatedList<NotifyCarToGet>> GetUserMatchAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotifyCarToGet>> GetUserNotificationsAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotifyCarToGet>> GetUserResponsesAsync(ulong userId, int pageNumber);
}
