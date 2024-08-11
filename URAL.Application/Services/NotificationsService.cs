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
        var cargoIdUserMatchs = notifyCargoRepository.GetUserMatch(userId).Select(x => x.CargoId).ToArray();
        var carIdUserMatchs = notifyCarRepository.GetUserMatch(userId).Select(x => x.CarId).ToArray();

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public PaginatedList<NotificationToGet> GetUserNotificationsAsync(string userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserNotifications(userId).Select(x => x.CargoId).ToArray();
        var carIdUserMatchs = notifyCarRepository.GetUserNotifications(userId).Select(x => x.CarId).ToArray();

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public PaginatedList<NotificationToGet> GetUserResponsesAsync(string userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserResponses(userId).Select(x => x.CargoId).ToArray();
        var carIdUserMatchs = notifyCarRepository.GetUserResponses(userId).Select(x => x.CarId).ToArray();

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    private NotificationToGet[] GetNotifications(IEnumerable<long> cargoNotifyIds, IEnumerable<long> carNotifyIds)
    {
        var cargos = cargoNotifyIds.Select(cargoRepository.GetById);
        var cars = carNotifyIds.Select(carRepository.GetById);

        var notifyCargos = cargos
            .Select(mapper.Map<Cargo, CargoToGet>)
            .Select(x => new NotificationToGet { Id=x.Id, Cargo=x});
        var notifyCars = cars
            .Select(mapper.Map<Car, CarToGet>)
            .Select(x => new NotificationToGet { Id=x.Id, Car=x});

        return notifyCargos.Concat(notifyCars).OrderBy(x => x.Id).ToArray();
    }
}
