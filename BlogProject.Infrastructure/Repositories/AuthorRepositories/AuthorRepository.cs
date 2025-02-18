using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.AppContext;
using BlogProject.Infrastructure.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
namespace BlogProject.Infrastructure.Repositories.AuthorRepositories;

public class AuthorRepository : EFBaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<Author?> GetByIdentityIdAsync(string identityId)
    {
        return await _table.FirstOrDefaultAsync(a => a.IdentityId == identityId);
    }
}
