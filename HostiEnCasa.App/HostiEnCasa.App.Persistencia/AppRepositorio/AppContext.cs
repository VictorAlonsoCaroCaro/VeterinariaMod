using Microsoft.EntityFrameworkCore;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }
        public DbSet<FamiliarDesignado> FamiliaresDesignados { get; set; }
        public DbSet<SignoVital> SignosVitales { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<SugerenciaCuidado> SugerenciasCuidado { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Server=LAPTOP-5I9PKCH7; Database=HospiEnCasa; Integrated Security=True;");
            }
        }

    }
}