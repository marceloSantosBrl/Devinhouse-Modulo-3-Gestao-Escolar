using GestaoEscolar_M3S01.Api.Subject.DTO;

namespace GestaoEscolar_M3S01.Api.Subject.Repository;

public interface ISubjectRepository
{
    public Task<ICollection<SubjectResponse>> GetSubjects(int? id, string? name);
}