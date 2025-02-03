namespace BlogProject.Domain.Core.Interfaces;

public interface IUpdatableEntity
{
    string UpdatedBy { get; set; }
    DateTime UpdatedDate { get; set; }
}
