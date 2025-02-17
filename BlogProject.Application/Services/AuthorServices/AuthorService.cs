using BlogProject.Application.DTOs.AuthorDTOs;
using BlogProject.Domain.Entities;
using BlogProject.Domain.Utilities.Concretes;
using BlogProject.Domain.Utilities.Interfaces;
using BlogProject.Infrastructure.Repositories.AuthorRepositories;
using Mapster;

namespace BlogProject.Application.Services.AuthorServices;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IDataResult<AuthorDTO>> AddAsync(AuthorCreateDTO authorCreateDTO)
    {
        if (await _authorRepository.AnyAsync(x => x.Email == authorCreateDTO.Email))
            return new ErrorDataResult<AuthorDTO>("Author cannot be created");
        var newAuthor = authorCreateDTO.Adapt<Author>();
        await _authorRepository.AddAsync(newAuthor);
        await _authorRepository.SaveChangesAsync();

        return new SuccessDataResult<AuthorDTO>(newAuthor.Adapt<AuthorDTO>(), "Author created successfully.");
    }

    public Task<IResult> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IDataResult<List<AuthorListDTO>>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        if (authors.Count() <= 0)
        {
            return new ErrorDataResult<List<AuthorListDTO>>(authors.Adapt<List<AuthorListDTO>>(), "No Authors found.");
        }
        return new SuccessDataResult<List<AuthorListDTO>>(authors.Adapt<List<AuthorListDTO>>(), "Authors listed successfully.");
    }

    public async Task<Guid> GetAuthorIdByIdentityId(string identityId)
    {
        var author = await _authorRepository.GetByIdentityIdAsync(identityId);
        if(author == null)
        {
            return Guid.Empty;
        }
        return author.Id;
    }

    public async Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null)
            return new ErrorDataResult<AuthorDTO>("Author not found.");
        var authorDto = author.Adapt<AuthorDTO>();
        return new SuccessDataResult<AuthorDTO>(authorDto, "Author retrieved successfully.");
    }

    public async Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO)
    {
        var authorToBeUpdated = await _authorRepository.GetByIdAsync(authorUpdateDTO.Id,false);
        if(authorToBeUpdated == null)
        {
            return new ErrorDataResult<AuthorDTO>("Author not found.");
        }
        var updatedAuthor = authorUpdateDTO.Adapt(authorToBeUpdated);
        await _authorRepository.UpdateAsync(updatedAuthor);
        await _authorRepository.SaveChangesAsync();

        return new SuccessDataResult<AuthorDTO>(updatedAuthor.Adapt<AuthorDTO>(), "Author updated successfully.");
    }
}
