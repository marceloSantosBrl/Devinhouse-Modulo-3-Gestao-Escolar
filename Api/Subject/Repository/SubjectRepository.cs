using FluentValidation;
using GestaoEscolar_M3S01.Api.Subject.DTO;
using GestaoEscolar_M3S01.Api.Subject.Mappings;
using GestaoEscolar_M3S01.Api.Subject.Validatior;
using GestaoEscolar_M3S01.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.Subject.Repository;

public class SubjectRepository: ISubjectRepository
{
    private readonly SchoolContext _schoolContext;
    private readonly SubjectValidator _validator;

    public SubjectRepository(SchoolContext schoolContext, SubjectValidator validator)
    {
        _schoolContext = schoolContext;
        _validator = validator;
    }

    public async Task<ICollection<SubjectResponse>> GetSubjects(int? id, string? name)
    {
        var query = _schoolContext.Subjects.Select(i => i);
        if (id != null)
        {
            query = query.Where(s => s.Id == id);
        }
        if (name != null)
        {
            query = query.Where(s => s.Name == name);
        }
        var entities = await query
            .Select(s => SubjectEntityResponse.GetResponse(s))
            .ToListAsync();
        return entities;
    }

    public async Task<Model.Subject> AddSubject(SubjectRequest request)
    {
        var entity = SubjectRequestEntity.GetSubject(request);
        await _validator.ValidateAndThrowAsync(entity);
        _schoolContext.Subjects.Add(entity);
        await _schoolContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeletSubject(int id)
    {
        var recordsChanged = await _schoolContext.Subjects
        .Where(s => s.Id == id)
        .ExecuteDeleteAsync();
        if (recordsChanged == 0) {
            throw new DbUpdateException("Failure to update the record");
        }
    }
}