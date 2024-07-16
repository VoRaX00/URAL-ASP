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

    public async Task<PaginatedList<NotificationToGet>> GetUserMatchAsync(ulong userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserMatch(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserMatch(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return await PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public async Task<PaginatedList<NotificationToGet>> GetUserNotificationsAsync(ulong userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserNotifications(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserNotifications(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return await PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    public async Task<PaginatedList<NotificationToGet>> GetUserResponsesAsync(ulong userId, int pageNumber)
    {
        var cargoIdUserMatchs = notifyCargoRepository.GetUserResponses(userId).Select(x => x.CargoId);
        var carIdUserMatchs = notifyCarRepository.GetUserResponses(userId).Select(x => x.CarId);

        var result = GetNotifications(cargoIdUserMatchs, carIdUserMatchs);
        return await PaginatedList<NotificationToGet>.Create(result, pageNumber, PageSize);
    }

    private IQueryable<NotificationToGet> GetNotifications(IQueryable<ulong> cargoNotifyIds, IQueryable<ulong> carNotifyIds)
    {
        var cargos = cargoNotifyIds.Select(x => cargoRepository.GetByID(x));
        var cars = carNotifyIds.Select(x => carRepository.GetByID(x));

        var notifyCargos = cargos.Select(x => mapper.Map<Cargo, NotifyCargoDto>(x)).Select(x => new NotificationToGet(x.Id, x));
        var notifyCars = cars.Select(x => mapper.Map<Car, NotifyCarDto>(x)).Select(x => new NotificationToGet(x.Id, x));

        return notifyCargos.Concat(notifyCars).OrderBy(x => x.Id);
    }
}
