using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class NotifyCargoGenerator : BaseNotifyGenerator<NotifyCargo>
{
    public NotifyCargoGenerator(List<Cargo> cargos, int count, List<Guid> userGuids) : base(count, userGuids)
    {
        var cargosCount = cargos.Count;
        notifyFaker
            .RuleFor(nc => nc.CargoId, f => f.Random.Long(0, cargosCount - 1))
            .RuleFor(nc => nc.SecondUserId, (f, nc) => cargos[(int)nc.CargoId - 1].UserId)
            .RuleFor(nc => nc.FirstUserId, (f, nc) => f.PickRandom(cargos.Where(x => x.UserId != nc.SecondUserId).Select(x => x.UserId)));
    }

    public override List<NotifyCargo> Generate()
    {
        return notifyFaker.Generate(count);
    }
}
