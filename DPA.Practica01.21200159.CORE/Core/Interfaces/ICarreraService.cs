using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Core.DTOs;

namespace DPA.Practica01._21200159.CORE.Core.Interfaces
{
    public interface ICarreraService
    {
        Task<int> Create(CarreraCreateDTO dto);
        IEnumerable<CarreraListDTO> GetAll();
        Task<CarreraDTO?> GetById(int id);
        Task Update(CarreraDTO dto);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
