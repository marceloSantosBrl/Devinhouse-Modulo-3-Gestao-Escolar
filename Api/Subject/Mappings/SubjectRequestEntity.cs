using GestaoEscolar_M3S01.Api.Subject.DTO;

namespace GestaoEscolar_M3S01.Api.Subject.Mappings;

public static class SubjectRequestEntity
{
    public static Model.Subject GetSubject(SubjectRequest request)
    {
        return new Model.Subject()
        {
            Name = request.Name
        };
    }
}