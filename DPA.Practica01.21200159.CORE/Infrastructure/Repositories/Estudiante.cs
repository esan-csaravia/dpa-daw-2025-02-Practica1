using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

[Table("Estudiante")]
[Index("CarreraId", Name = "IX_Estudiante_CarreraId")]
[Index("Correo", Name = "UQX_Estudiante_Correo", IsUnique = true)]
public partial class Estudiante
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Paterno { get; set; } = null!;

    [StringLength(100)]
    public string? Materno { get; set; }

    [StringLength(150)]
    public string Nombres { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    [StringLength(256)]
    public string Correo { get; set; } = null!;

    public int CarreraId { get; set; }

    [ForeignKey("CarreraId")]
    [InverseProperty("Estudiantes")]
    public virtual Carrera Carrera { get; set; } = null!;
}
