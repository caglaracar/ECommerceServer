using ECommerceServer.Application.Abstractions.Storage;
using ECommerceServer.Infrastructure.Services.Storage;
using ECommerceServer.Infrastructure.Services.Storage.Azure;
using ECommerceServer.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceServer.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}