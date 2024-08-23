using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Application.RequestModels.Cargo;
using URAL.Application.RequestModels.Notification;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class NotificationsService(
    IMapper mapper,
    INotifyCargoRepository notifyCargoRepository,
    INotifyCarRepository notifyCarRepository,
    ICargoRepository cargoRepository,
    ICarRepository carRepository) : INotificationsService
{
    public int PageSize { get; private set; } = 4;

    public PaginatedList<NotificationToGet> GetUserMatchAsync(string userId, int pageNumber)
    {
        var notifyCargo = notifyCargoRepository.GetUserMatch(userId);
        var notifyCar = notifyCarRepository.GetUserMatch(userId);
        return GetNotifications(notifyCargo, notifyCar, pageNumber);
    }

    public PaginatedList<NotificationToGet> GetUserNotificationsAsync(string userId, int pageNumber)
    {
        var notifyCargo = notifyCargoRepository.GetUserNotifications(userId);
        var notifyCar = notifyCarRepository.GetUserNotifications(userId);
        return GetNotifications(notifyCargo, notifyCar, pageNumber);
    }

    public PaginatedList<NotificationToGet> GetUserResponsesAsync(string userId, int pageNumber)
    {
        var notifyCargo = notifyCargoRepository.GetUserResponses(userId);
        var notifyCar = notifyCarRepository.GetUserResponses(userId);
        return GetNotifications(notifyCargo, notifyCar, pageNumber);
    }

    private PaginatedList<NotificationToGet> GetNotifications(IQueryable<NotifyCargo> notifyCargos, IQueryable<NotifyCar> notifyCars, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargos.Select(x => new LogisticNotifyId(x.Id, x.CargoId)).ToArray();
        var carIdUserMatchs = notifyCars.Select(x => new LogisticNotifyId(x.Id, x.CarId)).ToArray();

        var result = GetNotificationLogisticObjects(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    private NotificationToGet[] GetNotificationLogisticObjects(IEnumerable<LogisticNotifyId> cargoNotifyIds, IEnumerable<LogisticNotifyId> carNotifyIds)
    {
        var cargos = cargoNotifyIds.Select(x => new { x.Id, LogisticObject = cargoRepository.GetById(x.LogisticObjectId) });
        var cars = carNotifyIds.Select(x => new { x.Id, LogisticObject = carRepository.GetById(x.LogisticObjectId) });

        var notifyCargos = cargos
            .Select(x => new NotificationToGet { Id = x.Id, Cargo = mapper.Map<Cargo, CargoToGet>(x.LogisticObject) });
        var notifyCars = cars
            .Select(x => new NotificationToGet { Id=x.Id, Car = mapper.Map<Car, CarToGet>(x.LogisticObject) });

        return notifyCargos.Concat(notifyCars).OrderBy(x => x.Id).ToArray();
    }

    private class LogisticNotifyId
    {
        public LogisticNotifyId(long id, long logisticObjectId)
        {
            Id = id;
            LogisticObjectId = logisticObjectId;
        }

        public long Id { get; set; }

        public long LogisticObjectId { get; set; }
    }
}
