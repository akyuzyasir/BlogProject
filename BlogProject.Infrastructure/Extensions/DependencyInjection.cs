using BlogProject.Infrastructure.AppContext;
using BlogProject.Infrastructure.Repositories.ArticleRepositories;
using BlogProject.Infrastructure.Repositories.AuthorRepositories;
using BlogProject.Infrastructure.Repositories.SubjectRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProject.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(configuration.GetConnectionString(AppDbContext.DevConnectionString));
        });

        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        return services;
    }
}
