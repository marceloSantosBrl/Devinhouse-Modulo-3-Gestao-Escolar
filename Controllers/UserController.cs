using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar_M3S01.Controllers;

[Route("api/usuario")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser([FromRoute] int id)
    {
        try
        {
            var response = await _service.GetUserResponse(id);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromQuery] UserRequest request)
    {
        try
        {
            var user = await _service.CreateUser(request);
            return Created($"/usuario/{user.Id}", null);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutUser([FromRoute] int id,
        [FromQuery] UserRequest request)
    {
        try
        {
            var response = await _service.UpdateUser(id, request);
            return Ok(response);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        try
        {
            await _service.DeleteUser(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}