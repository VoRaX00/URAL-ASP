using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCar;

namespace URAL.Application.IServices;

public interface INotifyCarService
{
    public PaginatedList<NotifyCarToGet> GetAll();
    public NotifyCarToGet GetByID(ulong id);
    Task<ulong> AddAsync(NotifyCarToAdd notifyCargoToAdd);
    Task AddRangeAsync(IEnumerable<NotifyCarToAdd> entities);
    void Update(NotifyCarToUpdate notifyCarToUpdate);
    void UpdateRange(IEnumerable<NotifyCarToUpdate> entities);
    void Delete(NotifyCarToDelete notifyCarToDelete);
    void DeleteRange(IEnumerable<NotifyCarToDelete> entities);
    public PaginatedList<NotifyCarToGet> GetUserMatch(ulong userId);
    public PaginatedList<NotifyCarToGet> GetUserNotifications(ulong userId);
    public PaginatedList<NotifyCarToGet> GetUserResponses(ulong userId);
}
