using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Consola.Data
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
