using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.WorkoutMetric;

public class WorkoutMetricRepository : Repository<dal.Entities.WorkoutMetric>, IWorkoutMetricRepository
{
    public WorkoutMetricRepository(ExerciseDbContext dbContext) : base(dbContext) { }
}