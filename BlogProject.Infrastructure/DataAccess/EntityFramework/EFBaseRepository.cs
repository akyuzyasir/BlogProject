using BlogProject.Domain.Core.BaseEntities;
using BlogProject.Domain.Enums;
using BlogProject.Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace BlogProject.Infrastructure.DataAccess.EntityFramework;

public class EFBaseRepository<TEntity> : 
                                        IRepository, 
                                        IAsyncRepository, 
                                        IAsyncTransactionRepository, 
                                        IDeletableRepository<TEntity>, 
                                        IAsyncDeletableRepository<TEntity>, 
                                        IAsyncUpdatableRepository<TEntity>, 
                                        IAsyncQueryableRepository<TEntity>, 
                                        IAsyncOrderableRepository<TEntity>, 
                                        IAsyncInsertableRepository<TEntity>, 
                                        IAsyncFindableRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _table;
    public EFBaseRepository(DbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }
    protected IQueryable<TEntity> GetAllActives(bool tracking = true)
    {
        var values = _table.Where(x => x.Status != Status.Deleted);

        return tracking ? values : values.AsNoTracking();
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }
    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _table.Update(entity);
        return Task.FromResult(entry.Entity);
        //update operation is synchronous and only wrapped for consistency with other async methods.
    }
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return _context.Database.BeginTransactionAsync(cancellationToken);
    }
    public Task<IExecutionStrategy> CreateExecutionStrategy()
    {
        return Task.FromResult(_context.Database.CreateExecutionStrategy());
    }

    public async Task<IEnumerable<TEntity>> GetAllDataAsync(bool tracking = true)
    {
        return tracking ? await _table.ToListAsync() : await _table.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true)
    {
        return await GetAllActives(tracking).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
    {
        return await GetAllActives(tracking).Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes)
    {
        // Start building the query with tracking or no-tracking based on the parameter
        IQueryable<TEntity> query = tracking ? _context.Set<TEntity>().Where(expression) : _context.Set<TEntity>().AsNoTracking().Where(expression);

        // Apply each include to the query
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = include(query);
            }
        }

        // Execute the query and return the results as a list
        return await query.ToListAsync();
    }


    public async Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true)
    {
        var values = GetAllActives(tracking);
        return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderby, bool orderDesc = false, bool tracking = true)
    {
        var values = GetAllActives(tracking).Where(expression);
        return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await _table.AddAsync(entity);
        return entry.Entity;
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        return _table.AddRangeAsync(entities);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        return expression is null ? GetAllActives().AnyAsync() : GetAllActives().AnyAsync(expression);
    }

    public Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true)
    {
        var values = GetAllActives(tracking);

        return values.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
    {
        return GetAllActives(tracking).FirstOrDefaultAsync(expression);
    }

    public Task DeleteAsync(TEntity entity)
    {
        _table.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
        return _context.SaveChangesAsync();
    }
}
