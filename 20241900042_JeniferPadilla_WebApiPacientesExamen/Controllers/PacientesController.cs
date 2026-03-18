using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Services;
using Microsoft.AspNetCore.Mvc;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteAppService service;

        public PacientesController(PacienteAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var pacientes = await service.ObtenerTodos();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var paciente = await service.ObtenerPorId(id);
            if (paciente == null)
                return NotFound(new { message = "Paciente no encontrado." });

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Paciente paciente)
        {
            var (result, error) = await service.Agregar(paciente);
            if (error != null)
                return BadRequest(new { message = error });

            return CreatedAtAction(nameof(ObtenerPorId), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Paciente paciente)
        {
            var (result, error) = await service.Actualizar(id, paciente);
            if (error != null)
                return BadRequest(new { message = error });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var error = await service.Eliminar(id);
            if (error != null)
                return NotFound(new { message = error });

            return NoContent();
        }
    }
}
