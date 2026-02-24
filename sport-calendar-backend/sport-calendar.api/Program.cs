using Microsoft.EntityFrameworkCore;
using sport_calendar.api.InfrastructureServices;
using sport_calendar.dal.Context;
using sport_calendar.il.Migrator;

//builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExerciseDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();

//app
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var migrationService = scope.ServiceProvider.GetRequiredService<IDatabaseMigrationService>();
    await migrationService.MigrateAsync();
}

//middlewares
app.MapGet("/", async (ExerciseDbContext context) =>
{
    var statuses = await context.Statuses.ToListAsync();
    return statuses;
});
app.MapControllers();

app.Run();
