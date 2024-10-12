using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class NotifyCarsGenerator : BaseNotifyGenerator<NotifyCar>
{
    public NotifyCarsGenerator(List<Car> cars, int count, List<Guid> userGuids) : base(count, userGuids)
    {
        var carsCount = cars.Count;
        notifyFaker
            .RuleFor(nc => nc.CarId, f => f.Random.Int(1, carsCount))
            .RuleFor(nc => nc.SecondUserId, (f, nc) => cars[(int)nc.CarId - 1].UserId)
            .RuleFor(nc => nc.FirstUserId, (f, nc) => f.PickRandom(cars.Where(x => x.UserId != nc.SecondUserId).Select(x => x.UserId)));
    }

    public override List<NotifyCar> Generate()
    {
        return notifyFaker.Generate(count);
    }
}
