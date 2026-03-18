using _20241900042_JeniferPadilla_WebApiPacientesExamen.Entities;
using Microsoft.EntityFrameworkCore;

namespace _20241900042_JeniferPadilla_WebApiPacientesExamen.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NumeroIdentidad)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired();

                entity.Property(e => e.Activo)
                    .HasDefaultValue(true);
            });
        }
    }
}
