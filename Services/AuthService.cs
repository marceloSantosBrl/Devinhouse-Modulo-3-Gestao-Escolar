using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Repository;

namespace GestaoEscolar_M3S01.Services;

public class AuthService: IAuthService
{
    private readonly IUserRepository _repository;
    private readonly ICryptoService _crypto;

    public AuthService(IUserRepository repository, ICryptoService crypto)
    {
        _repository = repository ?? 
                      throw new ArgumentNullException(nameof(repository));
        _crypto = crypto ??
                  throw new ArgumentNullException(nameof(crypto));
    }
    
    public async Task<bool> GetAuthentication(LoginRequest request)
    {
        var userEntity = await _repository.GetUser(request.UserName);
        const int keySize = 64;
        var requestHash = _crypto.GetHash(request.Password, keySize, userEntity.Salt);
        return requestHash == userEntity.Hash;
    }
}