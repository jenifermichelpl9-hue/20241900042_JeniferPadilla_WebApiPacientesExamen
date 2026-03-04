using _20241900042_JENIFER_PADILLA_API_PACIENTES.Entities;

namespace _20241900042_JENIFER_PADILLA_API_PACIENTES.Features.Pacientes
{
    public class PacientesDomainService
    {
        public PacientesDomainService() {}
        public string ValidarPaciente(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
                return "El nombre completo no puede estar vacío.";

            if (string.IsNullOrWhiteSpace(paciente.NumeroIdentidad)
                || paciente.NumeroIdentidad.Length != 13)
                return "La identidad debe tener 13 caracteres sin guiones.";

            if (string.IsNullOrWhiteSpace(paciente.Telefono)
                || paciente.Telefono.Length < 8)
                return "El teléfono debe tener al menos 8 dígitos.";

            if (paciente.FechaNacimiento > DateTime.Now)
                return "La fecha de nacimiento no puede ser mayor a la actual.";

            return null;
        }
    }

}
