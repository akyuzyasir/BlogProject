using BlogProject.Domain.Core.BaseEntityConfigurations;
using BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Infrastructure.Configurations;

public class AuthorConfiguration: BaseUserConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);
    }
}
