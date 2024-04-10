using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using QuipuWeb.Dto;
using QuipuWeb.Validators;

namespace QuipuWeb
{
    public static class DependencyInjectionWeb
    {

        public static WebApplication AddMigration(this WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider
                        .GetRequiredService<AppDbContext>();

                    var migrationList = dbContext.Database.GetMigrations();
                    var migrationApplayed = dbContext.Database.GetAppliedMigrations();
                    var migrationPending = dbContext.Database.GetPendingMigrations();

                    Console.Write($"Migration DB; TotalMigrationFile:{migrationList.Count()} - TotalMigrationApplayed:{migrationApplayed.Count()} - TotalMigrationPending:{migrationPending.Count()}", 1);

                    // Here is the migration executed
                    dbContext.Database.Migrate();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }

            return app;

        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvc();
            services
              .AddScoped<IValidator<ClientDTO>, ClientDTOValidator>()
              .AddScoped<IValidator<ClientCreateUpdateRequestDTO>, ClientCreateUpdateRequestDTOValidator>()
              .AddScoped<IValidator<AddressDTO>, AddressDTOValidator>()
              .AddScoped<IValidator<AddressCreateUpdateRequestDTO>, AddressCreateUpdateRequestDTOValidator>();


            return services;
        }
    }
}
