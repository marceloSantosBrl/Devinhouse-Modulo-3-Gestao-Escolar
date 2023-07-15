using System.Data.Common;
using GestaoEscolar_M3S01.Api.Report.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar_M3S01.Api.Report;

[Route("api/student/{id:int}/reports")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportRepository _repository;

    public ReportController(IReportRepository repository)
    {
        _repository = repository;
    }
    
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet]
    public async Task<IActionResult> GetStudent([FromRoute] int id)
    {
        try
        {
            var response = await _repository.GetReport(id);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}