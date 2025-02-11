using BlogProject.Domain.Core.BaseEntityConfigurations;
using BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Infrastructure.Configurations;

public class ArticleConfiguration : AuditableEntityConfiguration<Article>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(128);
        builder.Property(a => a.Content).IsRequired();
        builder.Property(a=>a.Image).IsRequired(false);
    }
}
