namespace URAL.Application.Filter;

public class CargoFilter : Filter
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
}