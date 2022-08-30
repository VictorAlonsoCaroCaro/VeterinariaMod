using System;
using System.Collections.Generic;

#nullable disable

namespace HospiEnCasa.App.Consola.Data
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? TipoDocumentoId { get; set; }
        public int Genero { get; set; }
        public string Discriminator { get; set; }
        public string Licencia { get; set; }
        public DateTime? FechaExpLicencia { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
