using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.WorkoutGoal;

public class WorkoutGoalRepository: Repository<dal.Entities.WorkoutGoal>, IWorkoutGoalRepository
{
    public WorkoutGoalRepository(ExerciseDbContext dbContext) : base(dbContext)
    {
    }
}