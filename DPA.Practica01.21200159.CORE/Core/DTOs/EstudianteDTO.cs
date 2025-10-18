using System;

namespace DPA.Practica01._21200159.CORE.Core.DTOs
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Nombres { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string? Correo { get; set; }
        public int CarreraId { get; set; }
    }

    public class EstudianteListDTO
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Correo { get; set; }
    }

    public class EstudianteCreateDTO
    {
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Nombres { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string? Correo { get; set; }
        public int CarreraId { get; set; }
    }
}
