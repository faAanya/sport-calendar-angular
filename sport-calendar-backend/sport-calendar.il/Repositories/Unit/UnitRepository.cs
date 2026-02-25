using sport_calendar.dal.Context;
using sport_calendar.dal.Repositories;

namespace sport_calendar.il.Repositories.Unit;

public interface IUnitRepository : IRepository<dal.Entities.Unit> { }

public class UnitRepository : Repository<dal.Entities.Unit>, IUnitRepository
{
    public UnitRepository(ExerciseDbContext dbContext) : base(dbContext) { }
}