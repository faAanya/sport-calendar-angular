using Microsoft.EntityFrameworkCore;
using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.Workout;

public class WorkoutRepository : Repository<dal.Entities.Workout>, IWorkoutRepository
{
    public WorkoutRepository(ExerciseDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<dal.Entities.Workout>> GetFullWorkoutsByDateAsync(DateOnly date)
    {
        return await _dbContext.Workouts
            .AsNoTracking()
            .Include(w => w.Activity)
            .Include(w => w.Status)
            .Include(w => w.WorkoutGoals).ThenInclude(g => g.Unit)
            .Include(w => w.WorkoutMetrics)
            .Where(w=>w.WorkoutDate==date)
            .ToListAsync();
    }
}