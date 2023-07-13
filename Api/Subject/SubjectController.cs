using GestaoEscolar_M3S01.Api.Subject.DTO;
using GestaoEscolar_M3S01.Api.Subject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.Subject;

[Route("api/materia")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectRepository _repository;

    public SubjectController(ISubjectRepository repository)
    {
        _repository = repository;
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<IActionResult> GetSubject([FromQuery] int? id, 
        [FromQuery(Name = "nome")] string? name)
    {
        var response = await _repository.GetSubjects(id, name);
        if (response.Count == 0)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost]
    public async Task<IActionResult> AddSubject([FromBody] SubjectRequest request)
    {
        try
        {
            var response = await _repository.AddSubject(request);
            return Created($"api/materia?id={response.Id}", response);
        }
        catch (FluentValidation.ValidationException)
        {
            return BadRequest();
        }
        catch (DbUpdateException)
        {
            return Conflict();
        }
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSubject([FromRoute] int id){
        try {
            await _repository.DeletSubject(id);
            return StatusCode(StatusCodes.Status204NoContent);
        } catch (DbUpdateException) {
            return NotFound();
        }
    }
}
