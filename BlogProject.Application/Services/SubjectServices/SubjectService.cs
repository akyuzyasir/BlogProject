using BlogProject.Application.DTOs.SubjectDTOs;
using BlogProject.Domain.Entities;
using BlogProject.Domain.Utilities.Concretes;
using BlogProject.Domain.Utilities.Interfaces;
using BlogProject.Infrastructure.Repositories.SubjectRepositories;
using Mapster;

namespace BlogProject.Application.Services.SubjectServices;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<IDataResult<SubjectDTO>> AddAsync(SubjectCreateDTO subjectCreateDTO)
    {
        //if ( await _subjectRepository.AnyAsync(x => x.Name.ToLower() == subjectCreateDTO.Name.ToLower()))
        // Better approach, avoids unneccessary allocations.
        if (await _subjectRepository.AnyAsync(x => x.Name.Equals(subjectCreateDTO.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return new ErrorDataResult<SubjectDTO>("A subject with this name already exists.");
        }
        var newSubject = subjectCreateDTO.Adapt<Subject>();
        await _subjectRepository.AddAsync(newSubject);
        await _subjectRepository.SaveChangesAsync();
        return new SuccessDataResult<SubjectDTO>(newSubject.Adapt<SubjectDTO>(), "Subject created successfully.");
    }

    public Task<IResult> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IDataResult<List<SubjectListDTO>>> GetAllAsync()
    {
        var subjects = await _subjectRepository.GetAllAsync();
        if (subjects.Count() <= 0)
            return new ErrorDataResult<List<SubjectListDTO>>(subjects.Adapt<List<SubjectListDTO>>(), "No subjects found.");

        return new SuccessDataResult<List<SubjectListDTO>>(subjects.Adapt<List<SubjectListDTO>>(), "Subjects listed successfully.");
    }

    public async Task<IDataResult<SubjectDTO>> GetByIdAsync(Guid id)
    {
        var subject = await _subjectRepository.GetByIdAsync(id);
        if (subject is null)
            return new ErrorDataResult<SubjectDTO>("Subject not found.");

        var subjectDto = subject.Adapt<SubjectDTO>();
        return new SuccessDataResult<SubjectDTO>(subjectDto, "Subject retrieved successfully.");
    }

    public async Task<IDataResult<SubjectDTO>> UpdateAsync(SubjectUpdateDTO subjectUpdateDTO)
    {
        var subjectToBeUpdated = await _subjectRepository.GetByIdAsync(subjectUpdateDTO.Id, false);
        if (subjectToBeUpdated == null) return new ErrorDataResult<SubjectDTO>("Subject not found.");

        var updatedSubject = subjectUpdateDTO.Adapt(subjectToBeUpdated);
        await _subjectRepository.UpdateAsync(updatedSubject);
        await _subjectRepository.SaveChangesAsync();

        return new SuccessDataResult<SubjectDTO>(updatedSubject.Adapt<SubjectDTO>(), "Subject updated successfully.");
    }
}
