using BlogProject.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.UI.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}
