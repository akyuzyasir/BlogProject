using BlogProject.Domain.Enums;

namespace BlogProject.Domain.Core.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }
    Status Status { get; set; }
}
