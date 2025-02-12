using BlogProject.Domain.Entities;
using BlogProject.Infrastructure.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Infrastructure.Repositories.SubjectRepositories;

public class SubjectRepository : EFBaseRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(DbContext context) : base(context)
    {
    }
}
