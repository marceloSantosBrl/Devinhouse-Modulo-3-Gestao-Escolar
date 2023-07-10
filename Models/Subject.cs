using System.ComponentModel.DataAnnotations;

namespace GestaoEscolar_M3S01.Models;
public class Subject
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string Course { get; set;} = null!;
}