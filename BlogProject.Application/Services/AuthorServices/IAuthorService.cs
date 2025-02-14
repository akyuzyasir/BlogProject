using BlogProject.Application.DTOs.AuthorDTOs;
using BlogProject.Domain.Utilities.Interfaces;

namespace BlogProject.Application.Services.AuthorServices;

public interface IAuthorService
{
    Task<IDataResult<AuthorDTO>> AddAsync(AuthorCreateDTO authorCreateDTO);
    Task<IDataResult<AuthorDTO>> UpdateAsync(AuthorUpdateDTO authorUpdateDTO);
    Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id);
    Task<IResult> DeleteAsync(Guid id);
    Task<IDataResult<List<AuthorListDTO>>> GetAllAsync();
    Task<Guid> GetAuthorIdByIdentityId(string identityId);
}
