using System;
using System.Collections.Generic;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Data;

public partial class UniversidadDbContext : DbContext
{
    public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<vw_Estudiante> vw_Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasOne(d => d.Carrera).WithMany(p => p.Estudiantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estudiante_Carrera");
        });

        modelBuilder.Entity<vw_Estudiante>(entity =>
        {
            entity.ToView("vw_Estudiantes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
