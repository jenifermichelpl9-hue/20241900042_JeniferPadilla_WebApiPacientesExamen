using _20241900042_JENIFER_PADILLA_API_PACIENTES.Entities;

namespace _20241900042_JENIFER_PADILLA_API_PACIENTES.Features.Pacientes
{
    public class PacientesAppService
    {
        private List<Paciente> pacientes = new List<Paciente>();
        private readonly PacientesDomainService domainService;

        public PacientesAppService(PacientesDomainService domainService)
        {
            this.domainService = domainService;

            pacientes.Add(new Paciente
            {
                Id = 1,
                NombreCompleto = "Satoru Gojo",
                NumeroIdentidad = "1201200600048",
                FechaNacimiento = new DateTime(2006, 09, 01),
                Telefono = "96170463",
                Activo = true
            });

            pacientes.Add(new Paciente
            {
                Id = 2,
                NombreCompleto = "Toji Fushiguro",
                NumeroIdentidad = "1201200067897",
                FechaNacimiento = new DateTime(2000, 5, 10),
                Telefono = "32877107",
                Activo = true
            });

            pacientes.Add(new Paciente
            {
                Id = 3,
                NombreCompleto = "Nanami Kento",
                NumeroIdentidad = "1201200389007",
                FechaNacimiento = new DateTime(2003, 3, 15),
                Telefono = "97282045",
                Activo = true
            });
        }

        public List<Paciente> ObtenerTodos()
        {
            return pacientes;
        }

        public Paciente ObtenerPorId(int id)
        {
            return pacientes.FirstOrDefault(i => i.Id == id);
        }

        public string Agregar(Paciente paciente)
        {
            var error = domainService.ValidarPaciente(paciente);
            if (error != null)
                return error;

            paciente.Id = pacientes.Max(i => i.Id) + 1;
            pacientes.Add(paciente);
            return null;
        }

        public string Actualizar(int id, Paciente paciente)
        {
            var existente = ObtenerPorId(id);
            if (existente == null)
                return "Paciente no encontrado.";

            var error = domainService.ValidarPaciente(paciente);
            if (error != null)
                return error;

            existente.NombreCompleto = paciente.NombreCompleto;
            existente.NumeroIdentidad = paciente.NumeroIdentidad;
            existente.FechaNacimiento = paciente.FechaNacimiento;
            existente.Telefono = paciente.Telefono;
            existente.Activo = paciente.Activo;

            return null;
        }

        public string Eliminar(int id)
        {
            var paciente = ObtenerPorId(id);
            if (paciente == null)
                return "Paciente no encontrado.";

            pacientes.Remove(paciente);
            return null;
        }
    }
}
