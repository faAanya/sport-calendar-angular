using Microsoft.AspNetCore.Mvc;
using sport_calendar.dal.Entities;
using sport_calendar.il.Repositories.Workout;

namespace sport_calendar.api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutRepository _workoutRepo;

    public WorkoutController(IWorkoutRepository workoutRepo)
    {
        _workoutRepo = workoutRepo;
    }
    
    [HttpGet("day")]
    public async Task<IActionResult> GetDayDetails([FromQuery] DateOnly date, CancellationToken ct)
    {
        var data = await _workoutRepo.GetFullWorkoutsByDateAsync(date, ct);
        return Ok(data);
    }
    
    [HttpPost]
    public async Task CreateWorkout([FromBody] Workout newWorkout, CancellationToken ct)
    {
        _workoutRepo.AddItem(newWorkout);
        await _workoutRepo.SaveChangesAsync(ct);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkout(int id, [FromBody] Workout updatedWorkout, CancellationToken ct)
    {
        if (id != updatedWorkout.Id) return BadRequest("ID mismatch");

        _workoutRepo.UpdateItem(updatedWorkout); 
        await _workoutRepo.SaveChangesAsync(ct);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(int id, CancellationToken ct)
    {
        var workoutToDelete = new Workout { Id = id };
        
        _workoutRepo.DeleteItem(workoutToDelete);
        await _workoutRepo.SaveChangesAsync(ct);
        
        return NoContent(); 
    }
}