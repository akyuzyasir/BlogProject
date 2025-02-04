using BlogProject.Domain.Core.BaseEntities;

namespace BlogProject.Domain.Entities;

public class Subject : AuditableEntity
{
    public string Name { get; set; }

    // Nav Props
    public virtual IEnumerable<Article> Articles { get; set; }
}
