using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HostiEnCasa.App.Dominio;
using HostiEnCasa.App.Persistencia;

namespace HospiEnCasa.WebApp
{
    public class ListModel : PageModel
    {
        private static IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );
        public IEnumerable<Persona> listaPersonas;

        public void OnGet()
        {
            listaPersonas = _personaRepository.GetAll();
        }
    }
}
