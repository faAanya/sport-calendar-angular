namespace sport_calendar.dal.Migrator;

public interface IDatabaseMigrationService
{
    Task MigrateAsync();
}