using Microsoft.Extensions.DependencyInjection;
using URAL.Application.IRepositories;
using URAL.Infrastructure.Repositories;

namespace URAL.Infrastructure.Extension;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection repository)
    {
        repository.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
        repository.AddScoped<ICargoRepository, CargoRepository>();
        repository.AddScoped<ICarRepository, CarRepository>();
        repository.AddScoped<ILoadingTypeRepository, LoadingTypeRepository>();
        repository.AddScoped<INotifyCarRepository, NotifyCarRepository>();
        repository.AddScoped<INotifyCargoRepository, NotifyCargoRepository>();
        repository.AddScoped<IChatRepository, ChatRepository>();
        repository.AddScoped<IMessageRepository, MessageRepository>();
        return repository;
    }
}