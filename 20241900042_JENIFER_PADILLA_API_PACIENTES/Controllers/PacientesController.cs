using _20241900042_JENIFER_PADILLA_API_PACIENTES.Entities;
using _20241900042_JENIFER_PADILLA_API_PACIENTES.Features.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace _20241900042_JENIFER_PADILLA_API_PACIENTES.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly PacientesAppService service;

        public PacientesController(PacientesAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(service.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var paciente = service.ObtenerPorId(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Paciente paciente)
        {
            var error = service.Agregar(paciente);
            if (error != null)
                return BadRequest(error);

            return Created(string.Empty, paciente);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Paciente paciente)
        {
            var error = service.Actualizar(id, paciente);
            if (error != null)
                return BadRequest(error);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var error = service.Eliminar(id);
            if (error != null)
                return NotFound(error);

            return Ok();
        }
    }
}
