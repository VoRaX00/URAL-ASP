using URAL.Domain.Entities;

namespace URAL.FunctionalTests.Helpers.DataGenerators;

public class NotifyCargoGenerator : BaseNotifyGenerator<NotifyCargo>
{
    public NotifyCargoGenerator(List<Cargo> cargos, int count, List<Guid> userGuids) : base(count)
    {
        var cargosCount = cargos.Count;
        notifyFaker
            .RuleFor(nc => nc.CargoId,
                f => f.Random.Long(1, cargosCount))
            .RuleFor(nc => nc.SecondUserId,
                (f, nc) => cargos[(int)nc.CargoId - 1].UserId)
            .RuleFor(nc => nc.FirstUserId,
                (f, nc) => f.PickRandom(userGuids.Select(x => x.ToString()).Where(x => x != nc.SecondUserId)));
    }

    public override List<NotifyCargo> Generate()
    {
        return notifyFaker.Generate(count);
    }
}
