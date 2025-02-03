namespace BlogProject.Domain.Core.Interfaces;

public interface ICreatableEntity
{
    string CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
}
