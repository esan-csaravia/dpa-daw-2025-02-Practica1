using DPA.Practica01._21200159.CORE.Infrastructure.Data;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;
using DPA.Practica01._21200159.CORE.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var _connectionString = _configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UniversidadDbContext>(options =>
{
    options.UseSqlServer(_connectionString);
});
builder.Services.AddTransient<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddTransient<IEstudianteService, EstudianteService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DbContext registration (adjust connection string as needed)
/*builder.Services.AddDbContext<UniversidadDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversidadDB") ?? "Server=localhost;Database=UniversidadDB;Trusted_Connection=True;TrustServerCertificate=True"));
*/
// DI for repository and service (Estudiante)
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();

// DI for repository and service (Carrera)
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
builder.Services.AddScoped<ICarreraService, CarreraService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
