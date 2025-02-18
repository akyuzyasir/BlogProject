using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.AppContext;
using BlogProject.Infrastructure.DataAccess.EntityFramework;

namespace BlogProject.Infrastructure.Repositories.SubjectRepositories;

public class SubjectRepository : EFBaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(AppDbContext context) : base(context)
    {
    }
}
