using URAL.Application.IRepositories;
using URAL.Domain.Common;
using URAL.Domain.Enums;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class NotificationsRepository<TNotifyEntity> : BaseRepository<TNotifyEntity>, INotificationsRepository<TNotifyEntity> where TNotifyEntity : NotifyEntity
{
    protected UralDbContext _context;
    
    public IQueryable<TNotifyEntity> GetUserMatch(string userId)
    {
        return _context.Set<TNotifyEntity>().Where(notify => 
            (notify.FirstUserId == userId || notify.SecondUserId == userId) 
            && notify.FirstUserStatus == UserStatus.Yes && notify.SecondUserStatus == UserStatus.Yes);
    }

    public IQueryable<TNotifyEntity> GetUserNotifications(string userId)
    {
        return _context.Set<TNotifyEntity>().Where(notify => notify.SecondUserId == userId);
    }

    public IQueryable<TNotifyEntity> GetUserResponses(string userId)
    {
        return _context.Set<TNotifyEntity>().Where(notify => notify.FirstUserId == userId);
    }
}