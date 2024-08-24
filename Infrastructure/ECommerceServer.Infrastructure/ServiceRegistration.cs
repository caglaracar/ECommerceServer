using ECommerceServer.Application.Services;
using ECommerceServer.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceServer.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructreServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFileService, FileService>();
    }
}