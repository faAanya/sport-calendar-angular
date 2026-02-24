using System.Linq.Expressions;

namespace sport_calendar.dal.Repositories;

public interface IRepository<TEntity> where TEntity : class
{ 
    Task<IEnumerable<TEntity>> GetAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? includes);

    void AddItem(TEntity item);
    void UpdateItem(TEntity item);
    void DeleteItem(TEntity item); 
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}