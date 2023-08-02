using GestaoEscolar_M3S01.Models;

namespace GestaoEscolar_M3S01.Services;

public interface ITokenService
{
    public string GetToken(User user);
    public Task<string> GetToken(string userName);
}