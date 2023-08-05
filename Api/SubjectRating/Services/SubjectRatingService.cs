using GestaoEscolar_M3S01.Api.Subject.Repository;
using GestaoEscolar_M3S01.Api.SubjectRating.DTO;
using GestaoEscolar_M3S01.Api.SubjectRating.Repository;

namespace GestaoEscolar_M3S01.Api.SubjectRating.Services;

public class SubjectRatingService: ISubjectRatingService
{
    private readonly ISubjectRatingRepository _repository;

    public SubjectRatingService(ISubjectRatingRepository rating)
    {
        _repository = rating ?? 
                  throw new ArgumentNullException(nameof(rating));
    }
    
    public async Task<Models.SubjectRating> AddRating(SubjectRatingRequest request)
    {
        if (request.Mark is < 0 or > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(request.Mark));
        }
        var entity = new Models.SubjectRating
        {
            ReportId = request.ReportId,
            SubjectId = request.SubjectId,
            Mark = request.Mark
        };
        await _repository.AddSubjectReport(entity);
        return entity;
    }
}