using Microsoft.EntityFrameworkCore;
using ECommerceServer.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using ECommerceServer.Persistence;
using ECommerceServer.Persistence.Repositories;
using ECommerceServer.Application.Repositories;

namespace ECommerceServer.Domain
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();



        }
    }
}
