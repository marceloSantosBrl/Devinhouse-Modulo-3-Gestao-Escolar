using GestaoEscolar_M3S01.Api.Subject.DTO;
namespace GestaoEscolar_M3S01.Api.Subject.Mappings;

public static class SubjectEntityResponse
{
    public static SubjectResponse GetResponse(Model.Subject subject)
    {
        return new SubjectResponse()
        {
            Id = subject.Id,
            Name = subject.Name
        };
    }
}