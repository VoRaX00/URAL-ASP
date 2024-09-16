using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URAL.Application.Filters;
using URAL.Application.FiltersParameters;
using URAL.Application.IRepositories;
using URAL.Domain.Entities;

namespace URAL.Application.Extensions
{
    public static class FilterExtension
    {
        public static IServiceCollection AddExpressionFilters(this IServiceCollection services)
        {
            services.AddScoped<IExpressionFilter<Car, CarFilterParameter>, CarFilter>();
            services.AddScoped<IExpressionFilter<Cargo, CargoFilterParameter>, CargoFilter>();
            return services;
        }
    }
}
