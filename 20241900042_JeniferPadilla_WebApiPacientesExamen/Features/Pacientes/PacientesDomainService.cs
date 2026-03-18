using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Features.Pacientes
{
    public class PacientesDomainService
    {
        public PacientesDomainService() { }

        public string ValidarPaciente(Paciente paciente)
        {
            if (paciente == null)
                return "El paciente no puede ser nulo.";

            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
                return "El nombre completo no puede estar vacío.";

            if (string.IsNullOrWhiteSpace(paciente.NumeroIdentidad)
                || paciente.NumeroIdentidad.Length != 13
                || !paciente.NumeroIdentidad.All(char.IsDigit))
                return "La identidad debe tener 13 dígitos sin guiones.";

            if (string.IsNullOrWhiteSpace(paciente.Telefono)
                || paciente.Telefono.Length < 8
                || !paciente.Telefono.All(char.IsDigit))
                return "El teléfono debe tener al menos 8 dígitos.";

            if (paciente.FechaNacimiento > DateTime.Today)
                return "La fecha de nacimiento no puede ser mayor a la actual.";

            return null;
        }
    }
}