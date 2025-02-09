using BlogProject.Domain.Core.BaseEntities;
using BlogProject.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Domain.Core.BaseEntityConfigurations;

public class AuditableEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity : AuditableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.DeletedDate).IsRequired(false);
        builder.Property(x => x.DeletedBy).IsRequired(false);
        builder.HasQueryFilter(e => e.Status != Status.Deleted);
        //dbContext.AuditableEntities.IgnoreQueryFilters().ToListAsync(); // to bypass queryfilter
    }
}
