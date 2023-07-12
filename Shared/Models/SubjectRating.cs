using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestaoEscolar_M3S01.Api.Subject.Model;

namespace GestaoEscolar_M3S01.Models;

public class SubjectRating
{
    [Key] public int Id {get;set;}
    [Required] public Report Report {get;set;} = null!;
    [Required] [ForeignKey("Report")] public int ReportId {get;set;}
    [Required] public Subject Subject {get;set;} = null!;
    [Required] [ForeignKey("Subject")] public int SubjectId {get;set;}
    [Required] public int Mark {get;set;}
}