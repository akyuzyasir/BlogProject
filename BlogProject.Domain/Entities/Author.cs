using BlogProject.Domain.Core.BaseEntities;

namespace BlogProject.Domain.Entities;

public class Author: BaseUser
{

    // Nav Props
    public virtual IEnumerable<Article>? Articles { get; set; }
}
