using URAL.Domain.Common;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface INotificationsRepository<TNotifyEntity> where TNotifyEntity : NotifyEntity
{
    public IQueryable<TNotifyEntity> GetUserMatch(ulong userId);
    public IQueryable<TNotifyEntity> GetUserNotifications(ulong userId);
    public IQueryable<TNotifyEntity> GetUserResponses(ulong userId);
}
