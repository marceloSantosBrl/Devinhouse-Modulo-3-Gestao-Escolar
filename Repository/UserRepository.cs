using GestaoEscolar_M3S01.Models;
using GestaoEscolar_M3S01.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Repository;

public class UserRepository : IUserRepository
{
    private readonly SchoolContext _context;

    public UserRepository(SchoolContext context)
    {
        _context = context;
    }

    public async Task<User> GetUser(int id)
    {
        var user = await _context.Users.FirstAsync(u => u.Id == id);
        return user;
    }

    public async Task<int> AddUser(User user)
    {
        _context.Users.Add(user);
        var recordsChanged = await _context.SaveChangesAsync();
        return recordsChanged;
    }

    public async Task<int> UpdateUser(int userId, User user)
    {
        var userEntity = await _context.Users
            .FirstAsync(u => u.Id == userId);
        userEntity.UserName = user.UserName;
        userEntity.AccessType = user.AccessType;
        userEntity.Hash = user.Hash;
        var recordsChanged = await _context.SaveChangesAsync();
        return recordsChanged;
    }

    public async Task<int> DeleteUser(int userId)
    {
        var recordsChanged = await _context
            .Users
            .Where(u => u.Id == userId)
            .ExecuteDeleteAsync();
        return recordsChanged;
    }
}