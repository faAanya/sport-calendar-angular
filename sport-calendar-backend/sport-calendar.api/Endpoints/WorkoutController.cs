using Microsoft.AspNetCore.Mvc;
using sport_calendar.dal.Entities;
using sport_calendar.il.Repositories.Workout;
using sport_calendar.il.Repositories.WorkoutMetric;

namespace sport_calendar.api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly IWorkoutRepository _workoutRepo;
    private readonly IWorkoutMetricRepository _metricRepo;

    public CalendarController(IWorkoutRepository workoutRepo, IWorkoutMetricRepository metricRepo)
    {
        _workoutRepo = workoutRepo;
        _metricRepo = metricRepo;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetDayDetails([FromQuery] DateOnly date)
    {
        var data = await _workoutRepo.GetFullWorkoutsByDateAsync(date);
        return Ok(data);
    }
    
    [HttpPost("metric")]
    public async Task<IActionResult> AddProgress([FromBody] WorkoutMetric metric)
    {
        _metricRepo.AddItem(metric);
        await _metricRepo.SaveChangesAsync();
        return Ok();
    }
}