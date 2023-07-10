using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar_M3S01.Models;
public class Report
{
    [Key] public int Id { get; set;}
    [Required] public DateTime OrderDate {get; set;}
    [Required] public Student Student { get; set;} = null!;
    [Required] [ForeignKey("Student")] public int StudentId { get; set;}
}