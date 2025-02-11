using BlogProject.Domain.Core.Interfaces;
using BlogProject.Domain.Enums;

namespace BlogProject.Domain.Core.BaseEntities;

public abstract class BaseEntity : ICreatableEntity, IUpdatableEntity, IEntity
{
    public Guid Id { get; set; }
    // We added the CreatedDate and CreatedBy properties to the BaseEntity class to keep track of when and by whom the entity was created.
    public Status Status { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string? UpdatedBy { get; set; } = null!;
    public DateTime? UpdatedDate { get; set; }
}
