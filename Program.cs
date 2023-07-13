using GestaoEscolar_M3S01.Api.Subject.Repository;
using GestaoEscolar_M3S01.Api.Subject.Validatior;
using GestaoEscolar_M3S01.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContext>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<SubjectValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
