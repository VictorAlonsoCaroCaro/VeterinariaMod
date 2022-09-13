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
    public class CreateValidateModel : PageModel
    {
        private IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );
        public Persona persona = new Persona();
        
        public void OnGet()
        {
        }

        public IActionResult OnPost(Persona persona){
            
            
            //Validar los datos de la persona con annotations
            if( ! ModelState.IsValid ){
                return Page();
            }

            var result = _personaRepository.AdicionarPersona(persona);

            //Mostrar al front el resultado de la operación
            if( result > 0){
                ViewData["mensaje"] = "Se inserto correctamente";
            }else{
                ViewData["mensaje"] = "No se pudo insertar la persona";
            }

            return RedirectToPage("./List");
            
        }
    }
}
