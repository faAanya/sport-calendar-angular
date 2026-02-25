using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace sport_calendar.dal.Context;

public class ExerciseDbContextFactory : IDesignTimeDbContextFactory<ExerciseDbContext>
{
    public ExerciseDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExerciseDbContext>();

        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DbContext");
        optionsBuilder.UseSqlServer(connectionString);
            
        return new ExerciseDbContext(optionsBuilder.Options);
    }
}