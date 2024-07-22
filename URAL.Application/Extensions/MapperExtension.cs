﻿using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using URAL.Application.MapperRegisters;

namespace URAL.Application.Extensions;

public static class MapperExtension
{
    public static IServiceCollection RegisterMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        var registers = config.Scan(Assembly.GetAssembly(typeof(RequestModelsRegister)));
        config.Apply(registers);
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
        return services;
    }
}
