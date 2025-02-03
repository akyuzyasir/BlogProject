namespace BlogProject.Domain.Core.Interfaces;

public interface ISoftDeletableEntity
{
    string? DeletedBy { get; set; }
    DateTime? DeletedDate { get; set; }
}
