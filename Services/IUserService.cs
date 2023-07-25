using GestaoEscolar_M3S01.DTO;
using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Repository;

namespace GestaoEscolar_M3S01.Services;

public interface IUserService
{
    public Task<UserResponse> GetUserResponse(int id);
    public Task<User> CreateUser(UserRequest request, Func<UserRequest, User> mapping);
    public Task<UserRequest> UpdateUser(int userId, UserRequest request, 
        Func<string, string> hashAndSalt);
    public Task DeleteUser(int userId);
}