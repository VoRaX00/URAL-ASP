using URAL.Domain.Entities;

namespace URAL.FunctionalTests.Helpers.DataGenerators;

public class NotifyCarsGenerator : BaseNotifyGenerator<NotifyCar>
{
    public NotifyCarsGenerator(List<Car> cars, int count, List<Guid> userGuids) : base(count)
    {
        var carsCount = cars.Count;
        notifyFaker
            .RuleFor(nc => nc.CarId,
                f => f.Random.Int(1, carsCount))
            .RuleFor(nc => nc.SecondUserId,
                (f, nc) => cars[(int)nc.CarId - 1].UserId)
            .RuleFor(nc => nc.FirstUserId,
                (f, nc) => f.PickRandom(userGuids.Select(x => x.ToString()).Where(x => x != nc.SecondUserId)));
    }

    public override List<NotifyCar> Generate()
    {
        return notifyFaker.Generate(count);
    }
}
