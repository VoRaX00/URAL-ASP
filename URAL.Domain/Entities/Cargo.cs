using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class Cargo : BaseEntity
{
    public string Name { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public double CountPlace { get; set; }
    public DateOnly LoadingDate { get; set; }
    public DateOnly UnloadingDate { get; set; }
    public ulong Phone { get; set; }
    public string LoadingPlace { get; set; }
    public string UnloadingPlace { get; set; }
    public bool? Cash { get; set; }
    public bool? Cashless { get; set; }
    public bool? CashLessNds { get; set; }
    public bool? CashLessWithoutNds { get; set; }
    public double? PriceCash { get; set; }
    public double? PriceCashNds { get; set; }
    public double? PriceCashWithoutNds { get; set; }
    public bool? RequestPrice { get; set; }
    public string? Comment { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }

    public List<NotifyCargo> NotifyCargo { get; set; } = [];
}
