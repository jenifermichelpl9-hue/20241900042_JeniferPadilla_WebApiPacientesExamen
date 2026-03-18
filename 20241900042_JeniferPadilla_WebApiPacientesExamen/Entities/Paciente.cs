namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string NumeroIdentidad { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        public string Telefono { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }
}
