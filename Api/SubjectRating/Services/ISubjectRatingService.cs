using GestaoEscolar_M3S01.Api.SubjectRating.DTO;

namespace GestaoEscolar_M3S01.Api.SubjectRating.Services;

public interface ISubjectRatingService
{
    public Task<Models.SubjectRating> AddRating(SubjectRatingRequest request);
}