using sport_calendar.dal.Migrator;
using sport_calendar.il.Repositories.Workout;
using sport_calendar.il.Repositories.WorkoutGoal;
using sport_calendar.il.Repositories.WorkoutMetric;

namespace sport_calendar.api.Extensions.InfrastructureServices;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseMigrationService, DatabaseMigrationService>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IWorkoutGoalRepository, WorkoutGoalRepository>();
        services.AddScoped<IWorkoutMetricRepository, WorkoutMetricRepository>();

        return services;
    }
}