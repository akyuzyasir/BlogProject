using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.Interfaces;

namespace BlogProject.Infrastructure.Repositories.SubjectRepositories;

public interface ISubjectRepository :  IAsyncRepository, 
                                        IAsyncInsertableRepository<Subject>,
                                        IAsyncUpdatableRepository<Subject>,
                                        IAsyncDeletableRepository<Subject>,
                                        IAsyncFindableRepository<Subject>,
                                        IAsyncQueryableRepository<Subject>,
                                        IAsyncOrderableRepository<Subject>
{
}
