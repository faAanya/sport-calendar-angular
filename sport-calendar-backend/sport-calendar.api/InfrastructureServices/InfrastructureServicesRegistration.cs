using sport_calendar.dal.Migrator;
using sport_calendar.il.Migrator;

namespace sport_calendar.api.InfrastructureServices;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseMigrationService, DatabaseMigrationService>();

        return services;
    }
}