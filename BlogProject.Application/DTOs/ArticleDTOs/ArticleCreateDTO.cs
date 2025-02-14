namespace BlogProject.Application.DTOs.ArticleDTOs;

public class ArticleCreateDTO
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public byte[]? Image { get; set; }
    public Guid AuthorId { get; set; }
    public Guid SubjectId { get; set; }
    public TimeSpan ReadTime { get; set; }
}
