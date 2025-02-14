namespace BlogProject.Application.DTOs.AuthorDTOs;

public class AuthorCreateDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string IdentityId { get; set; } = null!;
}
