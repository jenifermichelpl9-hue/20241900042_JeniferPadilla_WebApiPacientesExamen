using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;
using _20241900042_JeniferPadilla_WebApiPacientesExamen.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext context;

        public PacienteRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await context.Pacientes
                .Where(p => p.Activo)
                .ToListAsync();
        }

        public async Task<Paciente> ObtenerPorId(int id)
        {
            return await context.Pacientes
                .FirstOrDefaultAsync(p => p.Id == id && p.Activo);
        }

        public async Task<Paciente> Agregar(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> Actualizar(Paciente paciente)
        {
            context.Pacientes.Update(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> Eliminar(int id)
        {
            var paciente = await context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            paciente.Activo = false;
            context.Pacientes.Update(paciente);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
