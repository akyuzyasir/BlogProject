using BlogProject.Domain.Core.Interfaces;

namespace BlogProject.Domain.Core.BaseEntities;

public abstract class AuditableEntity : BaseEntity, ISoftDeletableEntity
{
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}
