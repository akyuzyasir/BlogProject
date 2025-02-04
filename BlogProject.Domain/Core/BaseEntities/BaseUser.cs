namespace BlogProject.Domain.Core.BaseEntities
{
    public abstract class BaseUser : AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Gender { get; set; }
        public string? Image { get; set; }
        public string? IdentityId { get; set; }
    }
}
