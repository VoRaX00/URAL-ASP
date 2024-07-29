using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
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
        var cargoIdUserMatchs = notifyCargoRepository.GetUserMatch(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserMatch(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public PaginatedList<NotificationToGet> GetUserNotificationsAsync(string userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserNotifications(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserNotifications(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public PaginatedList<NotificationToGet> GetUserResponsesAsync(string userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserResponses(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserResponses(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    private NotificationToGet[] GetNotifications(IQueryable<ulong> cargoNotifyIds, IQueryable<ulong> carNotifyIds)
    {
        var cargos = cargoNotifyIds.Select(x => cargoRepository.GetById(x));
        var cars = carNotifyIds.Select(x => carRepository.GetById(x));

        IEnumerable<Notify> notifyCargos = cargos.Select(x => mapper.Map<Cargo, NotifyCargoDto>(x)).AsEnumerable();
        var notifyCars = cars.Select(x => mapper.Map<Car, NotifyCarDto>(x)).AsEnumerable();

        return notifyCargos.Concat(notifyCars).Select(x => new NotificationToGet(x.Id, x)).OrderBy(x => x.Id).ToArray();
    }
}
