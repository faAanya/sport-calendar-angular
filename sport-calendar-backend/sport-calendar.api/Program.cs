using Microsoft.EntityFrameworkCore;
using sport_calendar.api.Extensions.InfrastructureServices;
using sport_calendar.api.Extensions.Policies;
using sport_calendar.dal.Context;
using sport_calendar.dal.Migrator;

//builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExerciseDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));
builder.Services.AddCorsPolicy();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();

//app
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var migrationService = scope.ServiceProvider.GetRequiredService<IDatabaseMigrationService>();
    await migrationService.MigrateAsync();
}
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
