using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Repository;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

    public async Task<User> CreateUser(UserRequest request, Func<UserRequest, User> mapping)
    {
        var entity = mapping(request);
        await _userRepository.AddUser(entity);
        return entity;
    }


    public async Task<UserRequest> UpdateUser(int userId, 
        UserRequest request, 
        Func<string, string> hashAndSalt)
    {
        var user = await _userRepository.GetUser(userId);
        user.UserName = request.UserName ?? user.UserName;
        if (!string.IsNullOrEmpty(request.Password))
        {
            user.Hash = hashAndSalt(request.Password);
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