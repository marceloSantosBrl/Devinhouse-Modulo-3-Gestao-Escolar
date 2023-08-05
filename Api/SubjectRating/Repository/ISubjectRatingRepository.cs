using GestaoEscolar_M3S01.Api.SubjectRating.DTO;

namespace GestaoEscolar_M3S01.Api.SubjectRating.Repository;

public interface ISubjectRatingRepository
{
    public Task<SubjectRatingResponse> GetSubjectResponse(int studentId, int reportId);
    public Task<Models.SubjectRating> AddSubjectReport(Models.SubjectRating rating);
    public Task DeleteSubjectReport(int id);
}