using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Mappings;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Repository;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapping _mapping;
    private readonly ICryptoService _crypto;

    public UserService(IUserRepository userRepository, IUserMapping mapping, ICryptoService crypto)
    {
        _userRepository = userRepository ??
                          throw new ArgumentNullException(nameof(userRepository));
        _mapping = mapping ??
                   throw new ArgumentNullException(nameof(mapping));
        _crypto = crypto ??
                  throw new ArgumentNullException(nameof(crypto));
    }
    
    public async Task<UserResponse> GetUserResponse(int id)
    {
        var userEntity = await _userRepository.GetUser(id);
        return new UserResponse()
        {
            AccessType = userEntity.AccessType,
            Id = userEntity.Id,
            UserName = userEntity.UserName
        };
    }

    public async Task<User> CreateUser(UserRequest request)
    {
        var entity = _mapping.UserRequestToEntity(request);
        await _userRepository.AddUser(entity);
        return entity;
    }


    public async Task<UserRequest> UpdateUser(int userId, UserRequest request)
    {
        var user = await _userRepository.GetUser(userId);
        user.UserName = request.UserName ?? user.UserName;
        if (!string.IsNullOrEmpty(request.Password))
        {
            const int keySize = 64;
            user.Salt = _crypto.GetSalt(keySize);
            user.Hash = _crypto.GetHash(request.Password, keySize, user.Salt);
        }
        await _userRepository.UpdateUser(userId, user);
        return request;
    }

    public async Task DeleteUser(int userId)
    {
        var recordsChanged = await _userRepository
            .DeleteUser(userId);
        if (recordsChanged == 0)
        {
            throw new DbUpdateException();
        }
    }
}