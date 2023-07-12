
using System.ComponentModel.DataAnnotations;

namespace GestaoEscolar_M3S01.Models;

public class Subject
{
    [Key] public int Id {get;set;}
    [Required] public string Name {get;set;} = null!;
}