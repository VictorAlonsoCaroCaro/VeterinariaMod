using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HostiEnCasa.App.Persistencia;
using HostiEnCasa.App.Dominio;

namespace HospiEnCasa.Frontend.Pages
{
    public class ListModel : PageModel
    {
        private IRepositorioPersona personaRepository = new RepositorioPersona( new HostiEnCasa.App.Persistencia.AppContext() );
        public void OnGet()
        {
            var persona = new Persona{
                Nombre = "Juan Esteban",
                Apellidos = "Zambrano Ramirez",
                NumeroTelefono = "3019876543",
                Genero = Genero.Masculino,
                Discriminator = "Joven"
            };

            personaRepository.AddPersona(persona);
        }
    }
}
