﻿using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class BodyTypesGenerator : IDataGenerator<BodyType>
{
    public List<BodyType> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        return
        [
            new() { Name = "Jumbo" },
            new() { Name = "Eurotruck" },
            new() { Name = "Automatic coupling" },
            new() { Name = "Сar transporter" },
            new() { Name = "Tanker truck" }
        ];
    }
}