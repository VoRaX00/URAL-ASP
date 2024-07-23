using URAL.Domain.Common;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface INotificationsRepository<TNotifyEntity> where TNotifyEntity : NotifyEntity
{
    public IQueryable<TNotifyEntity> GetUserMatch(string userId);
    public IQueryable<TNotifyEntity> GetUserNotifications(string userId);
    public IQueryable<TNotifyEntity> GetUserResponses(string userId);
}
