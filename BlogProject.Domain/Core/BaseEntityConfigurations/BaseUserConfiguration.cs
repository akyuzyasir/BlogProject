using BlogProject.Domain.Core.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Domain.Core.BaseEntityConfigurations;

public class BaseUserConfiguration<TEntity> : AuditableEntityConfiguration<TEntity> where TEntity : BaseUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(63);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(63);
        builder.Property(x => x.Email).IsRequired();
    }
}
