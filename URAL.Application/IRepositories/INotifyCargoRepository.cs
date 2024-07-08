using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface INotifyCargoRepository : IBaseRepository<NotifyCargo>, INotificationsRepository<NotifyCargo>
{
}
