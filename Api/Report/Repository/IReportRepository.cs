using GestaoEscolar_M3S01.Api.Report.DTO;

namespace GestaoEscolar_M3S01.Api.Report.Repository;

public interface IReportRepository
{
    public Task<ReportResponse> GetReport(int id);
    public Task<ReportRequest> AddReport(ReportRequest request);
}