using BlogProject.Domain.Core.BaseEntities;

namespace BlogProject.Domain.Entities;

public class Article : AuditableEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public byte[]? Image { get; set; }
    public int ViewCount { get; set; }
    public TimeSpan ReadTime { get; set; }
    
    // Nav Props
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public Guid SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}
