using GestaoEscolar_M3S01.Api.Report.DTO;
using GestaoEscolar_M3S01.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.Report.Repository;

public class ReportRepository: IReportRepository
{
    private readonly SchoolContext _context;

    private ReportResponse EntityToResponse(Models.Report report)
    {
        return new ReportResponse()
        {
            Id = report.Id,
            OrderDate = report.OrderDate,
            StudentId = report.StudentId
        };
    }
    
    public ReportRepository(SchoolContext context)
    {
        _context = context;
    }
    
    public async Task<ReportResponse> GetReport(int id)
    {
        var entity = await _context.Reports
            .FirstAsync(r => r.StudentId == id);
        return EntityToResponse(entity);
    }
}