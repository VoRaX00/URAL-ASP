using URAL.Application.Base;
using URAL.Application.RequestModels.Notification;
using URAL.Application.RequestModels.NotifyCar;

namespace URAL.Application.IServices;

public interface INotificationsService
{
    public Task<PaginatedList<NotificationToGet>> GetUserMatchAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotificationToGet>> GetUserNotificationsAsync(ulong userId, int pageNumber);
    public Task<PaginatedList<NotificationToGet>> GetUserResponsesAsync(ulong userId, int pageNumber);
}
