using URAL.Domain.Common;
using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface INotificationsRepository<TNotifyEntity> where TNotifyEntity : NotifyEntity
{
    public IEnumerable<TNotifyEntity> GetUserMatch(ulong userId);
    public IEnumerable<TNotifyEntity> GetUserNotifications(ulong userId);
    public IEnumerable<TNotifyEntity> GetUserResponses(ulong userId);
}
