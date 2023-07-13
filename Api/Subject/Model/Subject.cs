using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Api.Subject.Model;

[Index(nameof(Name), IsUnique = true)]
public class Subject
{
    [Key] public int Id {get;set;}
    [Required] public string Name {get;set;} = null!;
}