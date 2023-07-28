using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Services;

namespace GestaoEscolar_M3S01.Mappings;

public class UserMapping: IUserMapping
{
    private readonly ICryptoService _crypto;

    public UserMapping(ICryptoService crypto)
    {
        _crypto = crypto ?? throw new NullReferenceException("crypto service is null");
    }
    
    public User UserRequestToEntity(UserRequest request)
    {
        var password = request.Password ??
                       throw new ArgumentException("Password field cant be null");
        var access = request.AccessType ??
                     throw new ArgumentException("AcessType field not present");
        var userName = request.UserName ??
                       throw new ArgumentException("UserNameFieldNotPresent");
        const int keySize = 64;
        var salt = _crypto.GetSalt(keySize);
        var hash = _crypto.GetHash(password, 64, salt);
        return new User
        {
            AccessType = access,
            UserName = userName,
            Hash = hash,
            Salt = salt
        };
    }
}