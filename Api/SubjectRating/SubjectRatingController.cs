using GestaoEscolar_M3S01.Api.SubjectRating.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar_M3S01.Api.SubjectRating;

[Route("api/student/{idStudent:int}/report/{idReport:int}/subject-rating")]
[ApiController]
public class SubjectRatingController : ControllerBase
{
    private readonly ISubjectRatingRepository _repository;

    public SubjectRatingController(ISubjectRatingRepository repository)
    {
        _repository = repository;
    }
    
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet]
    public async Task<IActionResult> GetStudentReport(int idStudent, int idReport)
    {
        try
        {
            var response = await _repository.GetSubjectResponse(idStudent, idReport);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}