using System.Linq.Expressions;
using System.Reflection;
using URAL.Domain.Entities;

namespace URAL.Application.Filters;

public class CargoFilter : LogisticFilter<Cargo>
{
    public double? Weight { get; set; }
    public double? CountPlace { get; set; }
    public DateOnly? LoadingDate { get; set; }
    public DateOnly? UnloadingDate { get; set; }
    public string? LoadingPlace { get; set; }
    public string? UnloadingPlace { get; set; }
    public double? PriceCash { get; set; }
    public double? PriceCashNds { get; set; }
    public double? PriceCashWithoutNds { get; set; }
    public bool? RequestPrice { get; set; }
    private static readonly PropertyInfo[] properties = typeof(CargoFilter).GetProperties();

    public override Expression<Func<Cargo, bool>> GetFilteringExpression()
    {
        return ApplyAllFiltering(properties);
    }
}