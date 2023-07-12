using GestaoEscolar_M3S01.Api.Subject.DTO;
using GestaoEscolar_M3S01.Api.Subject.Mappings;
using GestaoEscolar_M3S01.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.Subject.Repository;

public class SubjectRepository: ISubjectRepository
{
    private readonly SchoolContext _schoolContext;

    public SubjectRepository(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
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
}