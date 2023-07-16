using System.Data.Common;
using GestaoEscolar_M3S01.Api.Report.DTO;
using GestaoEscolar_M3S01.Api.Report.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetReport([FromRoute] int id)
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

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [HttpPost]
    public async Task<IActionResult> AddReport(ReportRequest request)
    {
        try
        {
            var response = await _repository.AddReport(request);
            return Created($"api/student/{response.StudentId}/reports", response);
        }
        catch (DbException)
        {
            return BadRequest();
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }

    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [HttpDelete]
    public async Task<IActionResult> DeleteReport([FromRoute] int id)
    {
        try
        {
            await _repository.DeleteReport(id);
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return NotFound();
        }
    }
}