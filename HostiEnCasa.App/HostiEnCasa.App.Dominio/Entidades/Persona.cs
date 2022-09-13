using System;
using System.ComponentModel.DataAnnotations;

namespace HostiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(50, ErrorMessage="La longitud maxima son 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="El apellido es requerido")]
        [StringLength(50, ErrorMessage="La longitud maxima son 50 caracteres.")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage="El número teléfonico es requerido")]
        [StringLength(50, ErrorMessage="La longitud maxima son 50 caracteres.")]
        public string NumeroTelefono { get; set; }
        [Required(ErrorMessage="El Genero es requerido")]
        public Genero Genero { get; set; }
        [Required(ErrorMessage="El Tipo de persona es requerido")]
        [StringLength(50, ErrorMessage="La longitud maxima son 50 caracteres.")]
        public string Discriminator { get; set; }

        //public List<Enfermera> Enfermeras { get; set; }
    }
}