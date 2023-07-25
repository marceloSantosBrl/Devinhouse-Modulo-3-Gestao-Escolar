using GestaoEscolar_M3S01.Models;

namespace GestaoEscolar_M3S01.DTO;

public class UserResponse
{
    public int Id { get; set; }
    public AccessType AccessType { get; set; }
    public string UserName { get; set; } = null!;
}