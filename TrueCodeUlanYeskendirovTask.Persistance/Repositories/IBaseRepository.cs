using System.Linq.Expressions;

namespace TrueCodeUlanYeskendirovTask.Repository.Repositories;

public interface IBaseRepository<TEntity, TKey> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<bool> ExistsAsync(TKey id);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> AsQueryable();
}