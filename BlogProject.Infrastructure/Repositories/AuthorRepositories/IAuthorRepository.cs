using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.Interfaces;

namespace BlogProject.Infrastructure.Repositories.AuthorRepositories;

public interface IAuthorRepository : IAsyncRepository,
                                        IAsyncInsertableRepository<Author>,
                                        IAsyncUpdatableRepository<Author>,
                                        IAsyncDeletableRepository<Author>,
                                        IAsyncFindableRepository<Author>,
                                        IAsyncQueryableRepository<Author>,
                                        IAsyncOrderableRepository<Author>
{
    Task<Author?> GetByIdentityIdAsync(string identityId);
}
