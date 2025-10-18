using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DPA.Practica01._21200159.CORE.Core.Interfaces;
using DPA.Practica01._21200159.CORE.Infrastructure.Repositories;

namespace DPA.Practica01._21200159.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _service;

        public EstudianteController(IEstudianteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var e = await _service.GetById(id);
            if (e == null) return NotFound();
            return Ok(e);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Estudiante estudiante)
        {
            var id = await _service.Create(estudiante);
            return CreatedAtAction(nameof(GetById), new { id }, estudiante);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id) return BadRequest();
            await _service.Update(estudiante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
