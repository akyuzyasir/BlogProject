using BlogProject.Application.DTOs.ArticleDTOs;
using BlogProject.Domain.Utilities.Interfaces;

namespace BlogProject.Application.Services.ArticleServices;

public interface IArticleService
{
    Task<IDataResult<ArticleDTO>> AddAsync(ArticleCreateDTO articleCreateDTO);
    Task<IDataResult<ArticleDTO>> UpdateAsync(ArticleUpdateDTO articleUpdateDTO);
    Task<IDataResult<ArticleDTO>> GetByIdAsync(Guid id);
    Task<IResult> DeleteAsync(Guid id, Guid authorId);
    Task<IDataResult<List<ArticleListDTO>>> GetAllAsync();
    Task<IDataResult<List<ArticleListDTO>>> GetAllByAuthorIdAsync(Guid authorId);
    Task<IDataResult<List<ArticleListDTO>>> GetAllBySubjectIdAsync(Guid subjectId);
    Task<IDataResult<List<ArticleListDTO>>> GetTop5ArticlesAsync();
    Task IncrementViewCountByArticleId(Guid articleId);

    
}
