using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TrueCodeUlanYeskendirovTask.Repository.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbSet<TEntity> _dbSet;
    private readonly TrueCodeDbContext _context;
    
    public BaseRepository(TrueCodeDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<bool> ExistsAsync(TKey id)
    {
        return await _dbSet.FindAsync(id) != null;
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _dbSet.Entry(entity).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    
    public IQueryable<TEntity> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}