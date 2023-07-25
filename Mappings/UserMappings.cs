using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Utils;

namespace GestaoEscolar_M3S01.Mappings;

public static class UserMappings
{
    public static Func<UserRequest, User> UserRequestToEntity = request =>
    {
        var password = request.Password ??
                       throw new ArgumentException("Password field cant be null");
        var hash = CryptoUtils.HashPasword(password);
        var access = request.AccessType ??
                     throw new ArgumentException("AcessType field not present");
        var userName = request.UserName ??
                       throw new ArgumentException("UserNameFieldNotPresent");
        return new User
        {
            AccessType = access,
            UserName = userName,
            Hash = hash
        };
    };
}