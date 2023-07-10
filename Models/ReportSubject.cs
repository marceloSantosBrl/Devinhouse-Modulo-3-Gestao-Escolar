using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar_M3S01.Models;

public class ReportsSubject
{
    [Key] public int Id {get;set;}
    [Required] public Report Report {get;set;} = null!;
    [Required] [ForeignKey("Report")] public int ReportId {get;set;}
    [Required] public Subject Subject {get;set;} = null!;
    [Required] [ForeignKey("Subject")] public int SubjectId {get;set;}
}