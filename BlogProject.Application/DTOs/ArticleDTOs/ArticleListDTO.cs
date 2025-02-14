namespace BlogProject.Application.DTOs.ArticleDTOs;

public class ArticleListDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public byte[]? Image { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public TimeSpan ReadTime { get; set; }
}
