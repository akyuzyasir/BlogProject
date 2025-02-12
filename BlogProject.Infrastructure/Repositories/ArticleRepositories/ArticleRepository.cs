using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Infrastructure.Repositories.ArticleRepositories;

public class ArticleRepository : EFBaseRepository<Article>, IArticleRepository
{
    public ArticleRepository(DbContext context) : base(context)
    {
    }
}
