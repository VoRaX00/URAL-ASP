using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URAL.Application.FiltersParameters;

public record CargoFilterParameter : LogisticParameter
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
