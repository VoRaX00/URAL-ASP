﻿namespace URAL.Application.RequestModels.Cargo;

public record CargoToAdd
{
    public string Name { get; init; }
    public double Length { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }
    public double Weight { get; init; }
    public double Volume { get; init; }
    public double CountPlace { get; init; }
    public DateOnly LoadingDate { get; init; }
    public DateOnly UnloadingDate { get; init; }
    public ulong Phone { get; init; }
    public string LoadingPlace { get; init; }
    public string UnloadingPlace { get; init; }
    public bool? Cash { get; init; }
    public bool? Cashless { get; init; }
    public bool? CashlessNds { get; init; }
    public bool? CashlessWithoutNds { get; init; }
    public double? PriceCash { get; init; }
    public double? PriceCashNds { get; init; }
    public double? PriceCashWithoutNds { get; init; }
    public bool? RequestPrice { get; init; }
    public string? Comment { get; init; }
}
