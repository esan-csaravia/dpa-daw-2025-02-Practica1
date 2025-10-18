using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DPA.Practica01._21200159.CORE.Core.DTOs;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarreraController : ControllerBase
    {
        private readonly ICarreraService _service;
        private readonly ICarreraRepository _repository;

        public CarreraController(ICarreraService service, ICarreraRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarreraListDTO>> GetCarreras()
        {
            var items = _service.GetAll();
            var dtos = items.Select(c => new CarreraListDTO { Id = c.Id, Nombre = c.Nombre });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarreraDTO>> GetCarrera(int id)
        {
            var carrera = await _service.GetById(id);

            if (carrera == null)
            {
                return NotFound();
            }

            var dto = new CarreraDTO { Id = carrera.Id, Nombre = carrera.Nombre };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CarreraDTO>> PostCarrera(CarreraCreateDTO createDto)
        {
            var carrera = new Carrera { Nombre = createDto.Nombre };
            var id = await _service.Create(carrera);

            var created = await _repository.GetById(id);
            var dto = new CarreraDTO { Id = created!.Id, Nombre = created.Nombre };

            return CreatedAtAction(nameof(GetCarrera), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, CarreraDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            if (!await _repository.Exists(id))
            {
                return NotFound();
            }

            var carrera = new Carrera { Id = dto.Id, Nombre = dto.Nombre };
            await _service.Update(carrera);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            if (!await _repository.Exists(id))
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}
