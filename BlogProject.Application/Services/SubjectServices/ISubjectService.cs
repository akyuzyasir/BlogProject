using BlogProject.Application.DTOs.SubjectDTOs;
using BlogProject.Domain.Utilities.Interfaces;

namespace BlogProject.Application.Services.SubjectServices;

public interface ISubjectService
{
    Task<IDataResult<SubjectDTO>> AddAsync(SubjectCreateDTO subjectCreateDTO);
    Task<IDataResult<SubjectDTO>> UpdateAsync(SubjectUpdateDTO subjectUpdateDTO);
    Task<IDataResult<SubjectDTO>> GetByIdAsync(Guid id);
    Task<IResult> DeleteAsync(Guid id);
    Task<IDataResult<List<SubjectListDTO>>> GetAllAsync();
}
