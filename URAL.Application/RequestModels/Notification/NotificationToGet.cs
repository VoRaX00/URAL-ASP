using URAL.Application.RequestModels.Car;
using URAL.Application.RequestModels.Cargo;

namespace URAL.Application.RequestModels.Notification;

public record NotificationToGet
{
    public long Id { get; init; }
    
    public CarToGet? Car {  get; init; }

    public CargoToGet? Cargo {  get; init; }
}
