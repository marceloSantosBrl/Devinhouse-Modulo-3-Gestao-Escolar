using System.ComponentModel.DataAnnotations;

namespace GestaoEscolar_M3S01.Models;
public class Student
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(150)] public string Name {get;set;} = null!;
}