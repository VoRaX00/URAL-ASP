using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class NotifyCarRepository : NotificationsRepository<NotifyCar>, INotifyCarRepository
{
    public NotifyCarRepository(UralDbContext context)
    {
        _context = context;
    }
}