using GestaoEscolar_M3S01.Api.Report.DTO;

namespace GestaoEscolar_M3S01.Api.Report.Repository;

public interface IReportRepository
{
    public Task<ReportResponse> GetReport(int studentId);
    public Task<ReportRequest> AddReport(ReportRequest request);
    public Task DeleteReport(int studentId);
}