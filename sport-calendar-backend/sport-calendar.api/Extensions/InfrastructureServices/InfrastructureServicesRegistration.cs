using sport_calendar.dal.Migrator;
using sport_calendar.il.Repositories.ActivityType;
using sport_calendar.il.Repositories.Unit;
using sport_calendar.il.Repositories.Workout;
using sport_calendar.il.Repositories.WorkoutGoal;

namespace sport_calendar.api.Extensions.InfrastructureServices;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseMigrationService, DatabaseMigrationService>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IWorkoutGoalRepository, WorkoutGoalRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();

        return services;
    }
}