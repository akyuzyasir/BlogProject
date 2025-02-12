using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.EntityFramework;
using BlogProject.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Repositories.ArticleRepositories;

public interface IArticleRepository :   IAsyncRepository, 
                                        IAsyncInsertableRepository<Article>,
                                        IAsyncUpdatableRepository<Article>,
                                        IAsyncDeletableRepository<Article>,
                                        IAsyncFindableRepository<Article>,
                                        IAsyncQueryableRepository<Article>,
                                        IAsyncOrderableRepository<Article>
{
}
