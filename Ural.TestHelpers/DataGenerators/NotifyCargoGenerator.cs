using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class NotifyCargoGenerator : BaseNotifyGenerator<NotifyCargo>
{
    public NotifyCargoGenerator(int cargoCount, int count, List<Guid> guid) : base(count, guid)
    {
        notifyFaker.RuleFor(nc => nc.CargoId, f => f.Random.Long(1, cargoCount));
    }

    public override List<NotifyCargo> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        return notifyFaker.Generate(count);
    }
}
