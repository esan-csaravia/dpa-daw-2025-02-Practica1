using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.CORE.Core.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repository;

        public EstudianteService(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Estudiante estudiante)
        {
            return await _repository.Create(estudiante);
        }

        public IEnumerable<Estudiante> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Estudiante?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(Estudiante estudiante)
        {
            await _repository.Update(estudiante);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
