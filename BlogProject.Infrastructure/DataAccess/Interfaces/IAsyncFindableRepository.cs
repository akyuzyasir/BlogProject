using BlogProject.Domain.Core.BaseEntities;
using System.Linq.Expressions;

namespace BlogProject.Infrastructure.DataAccess.Interfaces;

public interface IAsyncFindableRepository<TEntity> where TEntity : BaseEntity
{
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
}
