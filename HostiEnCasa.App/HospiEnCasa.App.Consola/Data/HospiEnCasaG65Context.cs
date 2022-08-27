using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospiEnCasa.App.Consola.Data
{
    public partial class HospiEnCasaG65Context : DbContext
    {
        public HospiEnCasaG65Context()
        {
        }

        public HospiEnCasaG65Context(DbContextOptions<HospiEnCasaG65Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5I9PKCH7; Database=HospiEnCasaG65; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasIndex(e => e.TipoDocumentoId, "IX_Personas_TipoDocumentoId");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.TipoDocumentoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
