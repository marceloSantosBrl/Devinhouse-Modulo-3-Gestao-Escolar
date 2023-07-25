using System.ComponentModel.DataAnnotations;
using GestaoEscolar_M3S01.Models;

namespace GestaoEscolar_M3S01.DTO;

public class UserRequest
{
    public AccessType? AccessType { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}