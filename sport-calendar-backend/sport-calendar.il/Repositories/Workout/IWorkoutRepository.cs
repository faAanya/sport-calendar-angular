using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.Workout;

public interface IWorkoutRepository : IRepository<dal.Entities.Workout> 
{
    Task<IEnumerable<dal.Entities.Workout>> GetFullWorkoutsByDateAsync(DateOnly date);
}