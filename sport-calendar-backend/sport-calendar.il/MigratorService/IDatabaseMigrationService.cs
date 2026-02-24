namespace sport_calendar.il.Migrator;

public interface IDatabaseMigrationService
{
    Task MigrateAsync();
}