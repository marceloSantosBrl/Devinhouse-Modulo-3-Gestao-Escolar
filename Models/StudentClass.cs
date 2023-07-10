using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar_M3S01.Models;

public class StudentClass
{
    [Key] public int Id { get; set; }
    [Required] public Student Student { get; set; } = null!;
    [Required] [ForeignKey("Student")] public int StudentId { get; set; }
    [Required] public Subject Class { get; set; } = null!;
    [Required][ForeignKey("Class")] public int ClassId { get; set; }
}
