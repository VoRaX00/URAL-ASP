using URAL.Application.Base;
using URAL.Application.RequestModels.Notification;
using URAL.Application.RequestModels.NotifyCar;

namespace URAL.Application.IServices;

public interface INotificationsService
{
    public Task<PaginatedList<NotificationToGet>> GetUserMatchAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotificationToGet>> GetUserNotificationsAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotificationToGet>> GetUserResponsesAsync(string userId, int pageNumber);
}
