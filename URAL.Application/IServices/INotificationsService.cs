using URAL.Application.Base;
using URAL.Application.RequestModels.Notification;

namespace URAL.Application.IServices;

public interface INotificationsService
{
    public PaginatedList<NotificationToGet> GetUserMatchAsync(string userId, int pageNumber);
    public PaginatedList<NotificationToGet> GetUserNotificationsAsync(string userId, int pageNumber);
    public PaginatedList<NotificationToGet> GetUserResponsesAsync(string userId, int pageNumber);
}
