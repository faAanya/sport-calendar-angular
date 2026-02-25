using Microsoft.AspNetCore.Mvc;
using sport_calendar.il.Repositories.ActivityType;
using sport_calendar.il.Repositories.Unit;
using sport_calendar.il.Repositories.Workout;

namespace sport_calendar.api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly IWorkoutRepository _workoutRepo;
    private readonly IUnitRepository _unitRepository;
    private readonly IActivityTypeRepository _activityTypeRepository;
    
    public CalendarController( IWorkoutRepository workoutRepository, IUnitRepository unitRepository, IActivityTypeRepository activityTypeRepository)
    {
        _workoutRepo = workoutRepository;
        _unitRepository = unitRepository;
        _activityTypeRepository = activityTypeRepository;
    }
    
    [HttpGet("date")]
    public async Task<IActionResult> GetDayDetails([FromQuery] DateOnly date, CancellationToken ct)
    {
        var data = await _workoutRepo.GetFullWorkoutsByDateAsync(date, ct);
        return Ok(data);
    }
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboardDetails(CancellationToken ct)
    {
        var units = await _unitRepository.GetAsync(cancellationToken:ct);
        var  activityTypes = await _activityTypeRepository.GetAsync(cancellationToken:ct);
        return Ok(new {units, activityTypes});
    }
}