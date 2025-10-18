using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Core.DTOs;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.CORE.Core.Services
{
    public class CarreraService : ICarreraService
    {
        private readonly ICarreraRepository _repository;

        public CarreraService(ICarreraRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(CarreraCreateDTO dto)
        {
            var entity = new Carrera { Nombre = dto.Nombre };
            return await _repository.Create(entity);
        }

        public IEnumerable<CarreraListDTO> GetAll()
        {
            return _repository.GetAll()
                .Select(c => new CarreraListDTO { Id = c.Id, Nombre = c.Nombre });
        }

        public async Task<CarreraDTO?> GetById(int id)
        {
            var c = await _repository.GetById(id);
            if (c == null) return null;
            return new CarreraDTO { Id = c.Id, Nombre = c.Nombre };
        }

        public async Task Update(CarreraDTO dto)
        {
            var entity = new Carrera { Id = dto.Id, Nombre = dto.Nombre };
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
