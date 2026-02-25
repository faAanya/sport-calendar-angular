using Microsoft.AspNetCore.Mvc;
using sport_calendar.dal.Entities;
using sport_calendar.il.Repositories.Workout;

namespace sport_calendar.api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController
{
    private readonly IWorkoutRepository _workoutRepo;

    public WorkoutController(IWorkoutRepository workoutRepo)
    {
        _workoutRepo = workoutRepo;
    }
    [HttpPost]
    public async Task CreateWorkout([FromBody] Workout newWorkout, CancellationToken ct)
    {
        _workoutRepo.AddItem(newWorkout);
        await _workoutRepo.SaveChangesAsync(ct);
    }
    [HttpDelete]
    public async Task DeleteWorkout([FromQuery] Workout deleteWorkout, CancellationToken ct)
    {
        _workoutRepo.DeleteItem(deleteWorkout);
        await _workoutRepo.SaveChangesAsync(ct);
    }
}