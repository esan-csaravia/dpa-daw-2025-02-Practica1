using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DPA.Practica01._21200159.CORE.Core.Interfaces;

namespace DPA.Practica01._21200159.CORE.Infrastructure.Repositories
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly UniversidadDbContext _context;

        public CarreraRepository(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            await _context.SaveChangesAsync();
            return carrera.Id;
        }

        public IEnumerable<Carrera> GetAll()
        {
            return _context.Carreras.AsNoTracking().ToList();
        }

        public async Task<Carrera?> GetById(int id)
        {
            return await _context.Carreras.FindAsync(id);
        }

        public async Task Update(Carrera carrera)
        {
            _context.Entry(carrera).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var c = await _context.Carreras.FindAsync(id);
            if (c != null)
            {
                _context.Carreras.Remove(c);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Carreras.AnyAsync(c => c.Id == id);
        }
    }
}
