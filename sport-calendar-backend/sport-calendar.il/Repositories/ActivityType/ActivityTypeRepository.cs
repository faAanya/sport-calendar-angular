using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.ActivityType;

public interface IActivityTypeRepository : IRepository<dal.Entities.ActivityType> { }
public class ActivityTypeRepository : Repository<dal.Entities.ActivityType>, IActivityTypeRepository
{
    public ActivityTypeRepository(ExerciseDbContext dbContext) : base(dbContext) { }
}
