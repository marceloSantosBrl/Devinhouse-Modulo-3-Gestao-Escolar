using GestaoEscolar_M3S01.Models;

namespace GestaoEscolar_M3S01.Repository;

public interface IUserRepository
{
    public Task<User> GetUser(int id);
    public Task<User> GetUser(string userName);
    public Task<int> AddUser(User user);
    public Task<int> UpdateUser(int userId, User user);
    public Task<int> DeleteUser(int userId);
}