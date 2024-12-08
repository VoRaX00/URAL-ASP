﻿using Microsoft.Extensions.DependencyInjection;
using URAL.Application.Hasher;
using URAL.Application.IServices;
using URAL.Application.Services;

namespace URAL.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBodyTypeService, BodyTypeService>();
        services.AddScoped<ICargoService, CargoService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<ILoadingTypeService, LoadingTypeService>();
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<INotifyCargoService, NotifyCargoService>();
        services.AddScoped<INotifyCarService, NotifyCarService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMessageEmailService, MessageEmailService>();
        services.AddScoped<IMessageService, MessageService>();  
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IHasher, AesHasher>();
        services.AddSignalR();
        return services;
    }
}
