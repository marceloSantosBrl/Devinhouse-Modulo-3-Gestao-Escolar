using GestaoEscolar_M3S01.DTO;

namespace GestaoEscolar_M3S01.Services;

public interface IAuthService
{
    public Task<bool> GetAuthentication(LoginRequest request);
}