using Microsoft.Extensions.DependencyInjection;
using URAL.Application.IRepositories;
using URAL.Infrastructure.Repositories;

namespace URAL.Infrastructure.Extension;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
        services.AddScoped<ICargoRepository, CargoRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ILoadingTypeRepository, LoadingTypeRepository>();
        services.AddScoped<INotifyCarRepository, NotifyCarRepository>();
        services.AddScoped<INotifyCargoRepository, NotifyCargoRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        return services;
    }
}