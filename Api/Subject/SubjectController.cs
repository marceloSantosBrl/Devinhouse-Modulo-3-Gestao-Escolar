using GestaoEscolar_M3S01.Api.Subject.Repository;
using Microsoft.AspNetCore.Mvc;

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
}
