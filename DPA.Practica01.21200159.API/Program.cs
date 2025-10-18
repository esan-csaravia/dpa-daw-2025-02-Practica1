using DPA.Practica01._21200159.CORE.Infrastructure.Data;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DPA.Practica01._21200159.CORE.Core.Services;

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


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
