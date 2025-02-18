using BlogProject.Application.Services.AccountServices;
using BlogProject.Application.Services.ArticleServices;
using BlogProject.Application.Services.AuthorServices;
using BlogProject.Application.Services.MailServices;
using BlogProject.Application.Services.SubjectServices;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProject.Application.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}
