using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Models;

public enum AccessType
{
    Teacher,
    Student
}

[Index(nameof(UserName), IsUnique = true)]
public class User
{
    [Key] [Required] public int Id { get; set; }
    [Required] public AccessType AccessType { get; set; }
    [Required] [MaxLength(100)] public string UserName { get; set; } = null!;
    [Required] [MaxLength(256)] public string Hash { get; set; } = null!;
}