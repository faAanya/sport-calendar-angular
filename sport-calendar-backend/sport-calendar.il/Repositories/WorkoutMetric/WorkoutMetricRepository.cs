using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.WorkoutMetric;

public interface IWorkoutMetricRepository:IRepository<dal.Entities.WorkoutMetric> { }
public class WorkoutMetricRepository : Repository<dal.Entities.WorkoutMetric>, IWorkoutMetricRepository
{
    public WorkoutMetricRepository(ExerciseDbContext dbContext) : base(dbContext) { }
}