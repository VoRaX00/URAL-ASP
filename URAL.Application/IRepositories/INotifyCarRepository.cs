using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface INotifyCarRepository : IBaseRepository<NotifyCar>, INotificationsRepository<NotifyCar>
{
}
