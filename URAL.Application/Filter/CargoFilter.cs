namespace URAL.Application.Filter;

public class CargoFilter : Filter
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
}