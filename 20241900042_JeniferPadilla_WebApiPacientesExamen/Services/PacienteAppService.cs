using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Features.Pacientes;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Repositories;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Services
{
    public class PacienteAppService
    {
        private readonly IPacienteRepository repository;
        private readonly PacientesDomainService domainService;

        public PacienteAppService(IPacienteRepository repository, PacientesDomainService domainService)
        {
            this.repository = repository;
            this.domainService = domainService;
        }

        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await repository.ObtenerTodos();
        }

        public async Task<Paciente> ObtenerPorId(int id)
        {
            return await repository.ObtenerPorId(id);
        }

        public async Task<(Paciente? paciente, string? error)> Agregar(Paciente paciente)
        {
            var error = domainService.ValidarPaciente(paciente);
            if (error != null)
                return (null, error);

            paciente.Activo = true;
            var result = await repository.Agregar(paciente);
            return (result, null);
        }

        public async Task<(Paciente? paciente, string? error)> Actualizar(int id, Paciente paciente)
        {
            var existente = await repository.ObtenerPorId(id);
            if (existente == null)
                return (null, "Paciente no encontrado.");

            var error = domainService.ValidarPaciente(paciente);
            if (error != null)
                return (null, error);

            existente.NombreCompleto = paciente.NombreCompleto;
            existente.NumeroIdentidad = paciente.NumeroIdentidad;
            existente.FechaNacimiento = paciente.FechaNacimiento;
            existente.Telefono = paciente.Telefono;
            existente.Activo = paciente.Activo;

            var result = await repository.Actualizar(existente);
            return (result, null);
        }

        public async Task<string?> Eliminar(int id)
        {
            var paciente = await repository.ObtenerPorId(id);
            if (paciente == null)
                return "Paciente no encontrado.";

            await repository.Eliminar(id);
            return null;
        }
    }
}
