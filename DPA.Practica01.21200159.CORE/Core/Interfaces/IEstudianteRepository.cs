using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.CORE.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<int> Create(Estudiante estudiante);
        IEnumerable<Estudiante> GetAll();
        Task<Estudiante?> GetById(int id);
        Task Update(Estudiante estudiante);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
