using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

[Table("Carrera")]
[Index("Nombre", Name = "UQ_Carrera_Nombre", IsUnique = true)]
public partial class Carrera
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Carrera")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
