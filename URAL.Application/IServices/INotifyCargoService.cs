using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCargo;

namespace URAL.Application.IServices;

public interface INotifyCargoService
{
    public PaginatedList<NotifyCargoToGet> GetAll();
    public NotifyCargoToGet GetByID(ulong id);
    Task<ulong> AddAsync(NotifyCargoToAdd notifyCargoToAdd);
    Task AddRangeAsync(IEnumerable<NotifyCargoToAdd> entities);
    void Update(NotifyCargoToUpdate notifyCargoToUpdate);
    void UpdateRange(IEnumerable<NotifyCargoToUpdate> entities);
    void Delete(NotifyCargoToDelete notifyCargoToDelete);
    void DeleteRange(IEnumerable<NotifyCargoToDelete> entities);
    public PaginatedList<NotifyCargoToGet> GetUserMatchAsync(ulong userId);
    public PaginatedList<NotifyCargoToGet> GetUserNotificationsAsync(ulong userId);
    public PaginatedList<NotifyCargoToGet> GetUserResponsesAsync(ulong userId);
}
