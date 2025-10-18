using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;
using DPA.Practica01._21200159.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DPA.Practica01._21200159.CORE.Core.Interfaces;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly UniversidadDbContext _context;

        public EstudianteRepository(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return estudiante.Id;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _context.Estudiantes.AsNoTracking().ToList();
        }

        public async Task<Estudiante?> GetById(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task Update(Estudiante estudiante)
        {
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var e = await _context.Estudiantes.FindAsync(id);
            if (e != null)
            {
                _context.Estudiantes.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Estudiantes.AnyAsync(e => e.Id == id);
        }
    }
}
