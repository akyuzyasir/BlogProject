using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
