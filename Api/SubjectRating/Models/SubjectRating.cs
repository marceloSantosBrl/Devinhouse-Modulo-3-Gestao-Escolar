using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar_M3S01.Api.SubjectRating.Models;

public class SubjectRating
{
    [Key] public int Id {get;set;}
    [Required] public Report.Models.Report Report {get;set;} = null!;
    [Required] [ForeignKey("Report")] public int ReportId {get;set;}
    [Required] public Subject.Model.Subject Subject {get;set;} = null!;
    [Required] [ForeignKey("Subject")] public int SubjectId {get;set;}
    [Required] public int Mark {get;set;}
}