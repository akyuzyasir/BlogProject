namespace BlogProject.Application.DTOs.ArticleDTOs;

public class ArticleDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public byte[]? Image { get; set; }
    public string AuthorFirstName { get; set; } = null!;
    public string AuthorLastName { get; set; } = null!;
    public string SubjectName { get; set; } = null!;
}
