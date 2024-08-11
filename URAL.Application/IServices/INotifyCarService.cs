using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCar;

namespace URAL.Application.IServices;

public interface INotifyCarService
{
    public Task<PaginatedList<NotifyCarToGet>> GetAllAsync(int pageNumber);
    public NotifyCarToGet? GetById(long id);
    Task<long> AddAsync(NotifyCarToAdd notifyCarToAdd);
    Task<bool> UpdateAsync(NotifyCarToUpdate notifyCarToUpdate);
    Task<bool> DeleteAsync(NotifyCarToDelete notifyCarToDelete);
    public Task<PaginatedList<NotifyCarToGet>> GetUserMatchAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotifyCarToGet>> GetUserNotificationsAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotifyCarToGet>> GetUserResponsesAsync(string userId, int pageNumber);
}
