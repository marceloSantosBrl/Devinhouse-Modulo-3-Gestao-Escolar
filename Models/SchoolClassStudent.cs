using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestaoEscolar_M3S01.Api.Student.Model;

namespace GestaoEscolar_M3S01.Models;

public class SchoolClassStudent
{
    [Key] public int Id { get; set; }
    [Required] public SchoolClass SchoolClass { get; set; } = null!;
    [Required] [ForeignKey("SchoolClass")] public int SchoolClassId { get; set; }
    [Required] public Student Student { get; set; } = null!;
    [Required][ForeignKey("Student")] public int StudentClassId { get; set; }
}
