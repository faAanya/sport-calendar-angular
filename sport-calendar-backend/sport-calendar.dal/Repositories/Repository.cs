using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using sport_calendar.dal.Context;

namespace sport_calendar.dal.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ExerciseDbContext _dbContext;

    protected Repository(ExerciseDbContext dbContext)
    {
        _dbContext = dbContext;   
    }

    public async Task<IEnumerable<TEntity>> GetAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[]? includes)
    {
        IQueryable<TEntity> query = tracking 
            ? _dbContext.Set<TEntity>() 
            : _dbContext.Set<TEntity>().AsNoTracking();
        
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        
        return await query.ToListAsync(cancellationToken);
    }

    public virtual void AddItem(TEntity item) => _dbContext.Set<TEntity>().Add(item);

    public virtual void UpdateItem(TEntity item) => _dbContext.Set<TEntity>().Update(item);

    public virtual void DeleteItem(TEntity item) => _dbContext.Set<TEntity>().Remove(item);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}