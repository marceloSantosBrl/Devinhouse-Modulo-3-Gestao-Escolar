using GestaoEscolar_M3S01.Api.Report.Models;
using GestaoEscolar_M3S01.Api.Student.Model;
using GestaoEscolar_M3S01.Api.Subject.Model;
using GestaoEscolar_M3S01.Api.SubjectRating.Models;
using GestaoEscolar_M3S01.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar_M3S01.Shared.Context;

public class SchoolContext : DbContext
{
    public DbSet<Report> Reports { get; set; }
    public DbSet<SchoolClass> SchoolClasses { get; set; }
    public DbSet<SchoolClassStudent> SchoolClassStudents { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<SubjectRating> SubjectRatings { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration _configuration;

    public SchoolContext(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    }
}