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
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarreraDTO>> GetCarrera(int id)
        {
            var dto = await _service.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CarreraDTO>> PostCarrera(CarreraCreateDTO createDto)
        {
            var id = await _service.Create(createDto);

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

            if (!await _service.Exists(id))
            {
                return NotFound();
            }

            await _service.Update(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            if (!await _service.Exists(id))
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}
