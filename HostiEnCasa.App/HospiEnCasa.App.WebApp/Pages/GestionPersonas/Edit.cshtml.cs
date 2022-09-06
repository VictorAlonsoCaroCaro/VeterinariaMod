using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HostiEnCasa.App.Dominio;
using HostiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.WebApp
{
    public class EditModel : PageModel
    {
        private IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );
        public Persona persona;

        public IActionResult OnGet(int Id)
        {
            persona = _personaRepository.Buscar(Id);

            if(persona == null){
                return RedirectToPage("./Listado");
                //ViewData["mensaje"] = "No existe la persona a actualizar";
            }else{
                return Page();
            }
        }
    }
}
