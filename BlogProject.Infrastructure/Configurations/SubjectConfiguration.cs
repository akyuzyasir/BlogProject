using BlogProject.Domain.Core.BaseEntityConfigurations;
using BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Infrastructure.Configurations;
public class SubjectConfiguration:AuditableEntityConfiguration<Subject>
{
    public override void Configure(EntityTypeBuilder<Subject> builder)
    {
        base.Configure(builder);

        builder.Property(s=>s.Name).IsRequired().HasMaxLength(128);
    }
}
