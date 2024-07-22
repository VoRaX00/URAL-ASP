using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class NotifyCargoRepository : NotificationsRepository<NotifyCargo>, INotifyCargoRepository
{
    NotifyCargoRepository(UralDbContext context)
    {
        _context = context;
    }
}