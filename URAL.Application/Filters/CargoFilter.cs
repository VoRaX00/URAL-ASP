using URAL.Domain.Entities;

namespace URAL.Application.Filters;

public class CargoFilter : LogisticFilter<Cargo>
{
    public double? weight { get; set; }
    public double? countPlace { get; set; }
    public DateOnly? loadingDate { get; set; }
    public DateOnly? unloadingDate { get; set; }
    public string? loadingPlace { get; set; }
    public string? unloadingPlace { get; set; }
    public double? priceCash { get; set; }
    public double? priceCashNds { get; set; }
    public double? priceCashWithoutNds { get; set; }
    public bool? requestPrice { get; set; }

    public override bool Apply(Cargo obj)
    {
        return base.Apply(obj) &&
            (requestPrice?.Equals(obj.RequestPrice) ?? true) &&
            (weight?.Equals(obj.Weight) ?? true) &&
            (countPlace?.Equals(obj.CountPlace) ?? true) &&
            (loadingDate?.Equals(obj.LoadingDate) ?? true) &&
            (unloadingDate?.Equals(obj.UnloadingDate) ?? true) &&
            (loadingPlace?.Equals(obj.LoadingPlace) ?? true) &&
            (unloadingPlace?.Equals(obj.UnloadingPlace) ?? true) &&
            (priceCash?.Equals(obj.UnloadingPlace) ?? true) &&
            (priceCashNds?.Equals(obj.UnloadingPlace) ?? true) &&
            (priceCashWithoutNds?.Equals(obj.UnloadingPlace) ?? true);
    }
}