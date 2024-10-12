using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class NotifyCarsGenerator : BaseNotifyGenerator<NotifyCar>
{
    public NotifyCarsGenerator(int carCount, int count, List<Guid> userGuid) : base(count, userGuid)
    {
        notifyFaker.RuleFor(nc => nc.CarId, f => f.Random.Int(1, carCount));
    }

    public override List<NotifyCar> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        return notifyFaker.Generate(count);
    }
}
