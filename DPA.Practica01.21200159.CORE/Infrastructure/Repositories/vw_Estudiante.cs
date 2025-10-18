using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

[Keyless]
public partial class vw_Estudiante
{
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

    [StringLength(150)]
    public string Carrera { get; set; } = null!;
}
