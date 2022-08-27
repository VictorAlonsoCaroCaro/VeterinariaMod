using System;

namespace HostiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String NumeroTelefono { get; set; }
        public Genero Genero { get; set; }
        public String Discriminator { get; set; }

        //public List<Enfermera> Enfermeras { get; set; }
    }
}