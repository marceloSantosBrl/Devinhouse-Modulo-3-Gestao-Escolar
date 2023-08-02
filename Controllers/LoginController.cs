using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar_M3S01.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public LoginController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService ??
                       throw new ArgumentNullException(nameof(authService));
        _tokenService = tokenService ?? 
                        throw new ArgumentNullException(nameof(tokenService));
    }


    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var authenticated = await _authService.GetAuthentication(loginRequest);
            if (!authenticated) return Unauthorized();
            var token = await _tokenService.GetToken(loginRequest.UserName);
            return Ok(token);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}