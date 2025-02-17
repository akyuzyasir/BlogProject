using BlogProject.Application.DTOs.ArticleDTOs;
using BlogProject.Domain.Entities;
using BlogProject.Domain.Utilities.Concretes;
using BlogProject.Domain.Utilities.Interfaces;
using BlogProject.Infrastructure.Repositories.ArticleRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services.ArticleServices;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<IDataResult<ArticleDTO>> AddAsync(ArticleCreateDTO articleCreateDTO)
    {
        var newArticle = articleCreateDTO.Adapt<Article>();
        try
        {
            await _articleRepository.AddAsync(newArticle);
            await _articleRepository.SaveChangesAsync();
            return new SuccessDataResult<ArticleDTO>(newArticle.Adapt<ArticleDTO>(), "Article created successfully.");
        }
        catch (Exception)
        {
            return new ErrorDataResult<ArticleDTO>(newArticle.Adapt<ArticleDTO>(), "Article cannot be created.");
        }
    }

    public async Task<IResult> DeleteAsync(Guid id, Guid authorId)
    {
        var article = await _articleRepository.GetByIdAsync(id);
        if(article == null)
        {
            return new ErrorResult("Article cannot be found.");
        }
        if(article.AuthorId != authorId)
        {
            return new ErrorResult("You are not authorized to delete this");
        }
        await _articleRepository.DeleteAsync(article);
        await _articleRepository.SaveChangesAsync();
        return new SuccessResult("Article removed successfully.");
    }

    public async Task<IDataResult<List<ArticleListDTO>>> GetAllAsync()
    {
        var articles = await _articleRepository.GetAllAsync(x=>x.CreatedDate,true);
        if(articles.Count() <= 0)
        {
            return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Articles not found.");
        }
        return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Articles listed successfully.");

    }

    public async Task<IDataResult<List<ArticleListDTO>>> GetAllByAuthorIdAsync(Guid authorId)
    {
        var articles = await _articleRepository.GetAllAsync(x=>x.AuthorId == authorId);
        if(articles.Count() <= 0)
        {
            return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(),"Articles not found.");
        }
        return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Articles listed successfully.");
    }

    public async Task<IDataResult<List<ArticleListDTO>>> GetAllBySubjectIdAsync(Guid subjectId)
    {
        var articles = await _articleRepository.GetAllAsync(x=> x.SubjectId == subjectId);
        if (articles.Count() <= 0)
        {
            return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Articles not found.");
        }
        return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Articles listed successfully.");
    }

    public async Task<IDataResult<ArticleDTO>> GetByIdAsync(Guid id)
    {
        var article = await _articleRepository.GetByIdAsync(id);
        if (article == null)
        {
            return new ErrorDataResult<ArticleDTO>(article.Adapt<ArticleDTO>(),"Article not found.");
        }
        return new SuccessDataResult<ArticleDTO>(article.Adapt<ArticleDTO>(), "Article details are shown.");
    }

    public async Task<IDataResult<List<ArticleListDTO>>> GetTop5ArticlesAsync()
    {
        var result = (await _articleRepository.GetAllAsync(x=>x.ViewCount, true)).Take(5);
        return new SuccessDataResult<List<ArticleListDTO>>(result.Adapt<List<ArticleListDTO>>(), $"Top {result.Count()} articles are shown.");
    }

    public async Task IncrementViewCountByArticleId(Guid articleId)
    {
        var article = await _articleRepository.GetByIdAsync(articleId);
        article.ViewCount++;
        await _articleRepository.UpdateAsync(article);
        await _articleRepository.SaveChangesAsync();


    }

    public async Task<IDataResult<ArticleDTO>> UpdateAsync(ArticleUpdateDTO articleUpdateDTO)
    {
        var articleToBeUpdated = await _articleRepository.GetByIdAsync(articleUpdateDTO.Id,false);
        if (articleToBeUpdated == null)
            return new ErrorDataResult<ArticleDTO>("Article not found.");
        var updatedArticle = articleUpdateDTO.Adapt(articleToBeUpdated);
        await _articleRepository.UpdateAsync(updatedArticle);
        await _articleRepository.SaveChangesAsync();

        return new SuccessDataResult<ArticleDTO>(updatedArticle.Adapt<ArticleDTO>(), "Article updated successfully.");
    }
}
