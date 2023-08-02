using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Repository;
using Microsoft.IdentityModel.Tokens;

namespace GestaoEscolar_M3S01.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public TokenService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration ??
                         throw new ArgumentNullException(nameof(configuration));
        _userRepository = userRepository;
    }

    public string GetToken(User user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes
        (_configuration["Jwt:Key"]?? string.Empty);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []{
                new Claim("sub", user.UserName),
                new Claim("role", user.AccessType.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }

    public async Task<string> GetToken(string userName)
    {
        var user = await _userRepository.GetUser(userName);
        return GetToken(user);
    }
}