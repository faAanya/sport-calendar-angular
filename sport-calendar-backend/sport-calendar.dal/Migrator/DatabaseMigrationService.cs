using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sport_calendar.dal.Context;
using sport_calendar.il.Migrator;

namespace sport_calendar.dal.Migrator;

public class DatabaseMigrationService : IDatabaseMigrationService
{
    private readonly ExerciseDbContext _context;
    private readonly ILogger<DatabaseMigrationService> _logger;

    public DatabaseMigrationService(ExerciseDbContext context, ILogger<DatabaseMigrationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task MigrateAsync()
    {
        _logger.LogInformation("Starting database migration process...");

        int retryCount = 10;
        for (int i = 0; i < retryCount; i++)
        {
            try
            {
                _logger.LogInformation("Connected to SQL Server.");

                await _context.Database.MigrateAsync();

                _logger.LogInformation("Database migration and seeding applied successfully.");
                return;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Attempt {i + 1} failed: {ex.Message}. Retrying in 2s...");
                await Task.Delay(2000);
            }
        }

        throw new Exception("Could not connect to SQL Server after multiple retries.");
    }
}