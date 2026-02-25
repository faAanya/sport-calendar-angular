using Microsoft.AspNetCore.Mvc;
using sport_calendar.il.Repositories.ActivityType;
using sport_calendar.il.Repositories.Unit;

namespace sport_calendar.api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
    private readonly IUnitRepository _unitRepository;
    private readonly IActivityTypeRepository _activityTypeRepository;
    
    public CalendarController(IUnitRepository unitRepository, IActivityTypeRepository activityTypeRepository)
    {
        _unitRepository = unitRepository;
        _activityTypeRepository = activityTypeRepository;
    }
    
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboardDetails(CancellationToken ct)
    {
        var units = await _unitRepository.GetAsync(cancellationToken:ct);
        var  activityTypes = await _activityTypeRepository.GetAsync(cancellationToken:ct);
        return Ok(new {units, activityTypes});
    }
}