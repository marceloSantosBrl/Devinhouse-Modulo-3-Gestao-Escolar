using GestaoEscolar_M3S01.Api.SubjectRating.DTO;
using GestaoEscolar_M3S01.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.SubjectRating.Repository;

public class SubjectRatingRepository: ISubjectRatingRepository
{
    private readonly SchoolContext _context;

    public SubjectRatingRepository(SchoolContext context)
    {
        _context = context;
    }
    
    public async Task<SubjectRatingResponse> GetSubjectResponse(int studentId, int reportId)
    {
        var entity = await _context.SubjectRatings
            .FirstAsync(s => s.Report.Id == reportId && 
                             s.Report.StudentId == studentId);
        var response = new SubjectRatingResponse()
        {
            Id = entity.Id,
            Mark = entity.Mark,
            ReportId = entity.ReportId,
            SubjectId = entity.SubjectId
        };
        return response;
    }

    public async Task<Models.SubjectRating> AddSubjectReport(Models.SubjectRating rating)
    {
        _context.SubjectRatings.Add(rating);
        await _context.SaveChangesAsync();
        return rating;
    }

    // public async Task<Models.SubjectRating> AddSubjectReport(Models.SubjectRating entity)
    // {
    //     _context.SubjectRatings.Add(entity);
    //     await _context.SaveChangesAsync();
    //     return entity;
    // }

    public async Task DeleteSubjectReport(int id)
    {
        var recordsChanged = await _context.SubjectRatings
            .Where(sr => sr.Id == id)
            .ExecuteDeleteAsync();
        if (recordsChanged == 0)
        {
            throw new DbUpdateException();
        }
    }
}