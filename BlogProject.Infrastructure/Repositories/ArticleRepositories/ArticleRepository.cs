using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.AppContext;
using BlogProject.Infrastructure.DataAccess.EntityFramework;
namespace BlogProject.Infrastructure.Repositories.ArticleRepositories;

public class ArticleRepository : EFBaseRepository<Article>, IArticleRepository
{
    public ArticleRepository(AppDbContext context) : base(context)
    {
    }
}
