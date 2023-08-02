using System.Text;
using GestaoEscolar_M3S01.Api.Report.Repository;
using GestaoEscolar_M3S01.Api.Subject.Repository;
using GestaoEscolar_M3S01.Api.Subject.Validatior;
using GestaoEscolar_M3S01.Api.SubjectRating.Repository;
using GestaoEscolar_M3S01.Mappings;
using GestaoEscolar_M3S01.Repository;
using GestaoEscolar_M3S01.Services;
using GestaoEscolar_M3S01.Shared.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var _configuration = WebApplication.CreateBuilder(args);

// Add services to the container.

_configuration.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_configuration.Services.AddEndpointsApiExplorer();
_configuration.Services.AddSwaggerGen();
_configuration.Services.AddDbContext<SchoolContext>();
_configuration.Services.AddScoped<ISubjectRepository, SubjectRepository>();
_configuration.Services.AddScoped<IReportRepository, ReportRepository>();
_configuration.Services.AddScoped<ISubjectRatingRepository, SubjectRatingRepository>();
_configuration.Services.AddScoped<IUserRepository, UserRepository>();
_configuration.Services.AddScoped<IUserService, UserService>();
_configuration.Services.AddScoped<ICryptoService, CryptoService>();
_configuration.Services.AddScoped<IUserMapping, UserMapping>();
_configuration.Services.AddScoped<SubjectValidator>();
_configuration.Services.AddScoped<IAuthService, AuthService>();

_configuration.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = _configuration.Configuration["Jwt:Issuer"],
        ValidAudience = _configuration.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_configuration.Configuration["Jwt:Key"] ?? string.Empty)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
_configuration.Services.AddAuthorization();
var app = _configuration.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
