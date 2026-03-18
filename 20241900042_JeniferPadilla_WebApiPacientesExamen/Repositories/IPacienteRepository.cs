using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Repositories
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObtenerTodos();
        Task<Paciente> ObtenerPorId(int id);
        Task<Paciente> Agregar(Paciente paciente);
        Task<Paciente> Actualizar(Paciente paciente);
        Task<bool> Eliminar(int id);
    }
}
