namespace BlogProject.Infrastructure.DataAccess.Interfaces;

public interface IDeletableRepository<TEntity> :IRepository
{
    void Delete(TEntity entity);
}
