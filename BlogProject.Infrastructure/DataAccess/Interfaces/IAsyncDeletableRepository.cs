using BlogProject.Domain.Core.BaseEntities;

namespace BlogProject.Infrastructure.DataAccess.Interfaces;

public interface IAsyncDeletableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
    Task DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
}
