using GestaoEscolar_M3S01.Api.SubjectRating.DTO;
using GestaoEscolar_M3S01.Api.SubjectRating.Repository;
using GestaoEscolar_M3S01.Api.SubjectRating.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.SubjectRating;

[Route("api/student/{idStudent:int}/report/{idReport:int}/subject-rating")]
[ApiController]
public class SubjectRatingController : ControllerBase
{
    private readonly ISubjectRatingRepository _repository;
    private readonly ISubjectRatingService _subjectRatingService;

    public SubjectRatingController(ISubjectRatingRepository repository, 
        ISubjectRatingService subjectRatingService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _subjectRatingService = subjectRatingService ?? throw new ArgumentNullException(nameof(subjectRatingService));
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

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [Authorize(Policy = "Teacher")]
    [HttpPost]
    public async Task<IActionResult> AddStudentReport([FromBody] SubjectRatingRequest request)
    {
        try
        {
            var entity = await  _subjectRatingService.AddRating(request);
            return Created($"", entity);
        }
        catch (DbUpdateException)
        {
            return Conflict();
        }
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = "Teacher")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudentReport([FromRoute] int id)
    {
        try
        {
            await _repository.DeleteSubjectReport(id);
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return NotFound();
        }
    }
}