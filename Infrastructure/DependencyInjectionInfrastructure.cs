using Application.Persistence;
using Application.Service;
using Domain.Entity;
using Infrastructure.Persistence;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInterfaceDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            var value = configuration.GetSection("ConfigurationDB:ConnectionStrings").Value;

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(value,
                b => b.MigrationsAssembly("Infrastructure")), ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddInterface(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClientService, ClientService>()
                .AddScoped<IAddressService, AddressService>();

            return services;
        }
    }
}
