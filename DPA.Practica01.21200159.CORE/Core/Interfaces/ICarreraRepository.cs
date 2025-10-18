using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.CORE.Core.Interfaces
{
    public interface ICarreraRepository
    {
        Task<int> Create(Carrera carrera);
        IEnumerable<Carrera> GetAll();
        Task<Carrera?> GetById(int id);
        Task Update(Carrera carrera);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
