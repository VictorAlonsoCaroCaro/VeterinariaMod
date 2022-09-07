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
                return RedirectToPage("./List");
                //ViewData["mensaje"] = "No existe la persona a actualizar";
            }else{
                return Page();
            }
        }

        public IActionResult OnPost(){

            //Capturar los datos
            var id = Request.Form["Id"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var telefono = Request.Form["telefono"];
            var genero = Request.Form["genero"];
            
            //Validar los datos

            var personaResult = _personaRepository.Buscar( Int32.Parse(id) );

            if( personaResult != null){

                personaResult.Nombre = nombre;
                personaResult.Apellidos = apellido;
                personaResult.NumeroTelefono = telefono;
                personaResult.Genero = (genero == "0" ? Genero.Femenino : Genero.Masculino);
            
                var result = _personaRepository.Update(personaResult);

                if( result > 0){
                    ViewData["mensaje"] = "Se actualizo correctamente";
                }else{
                    ViewData["mensaje"] = "No se pudo actualizar";
                }

            }else{
                ViewData["mensaje"] = "La persona a actualizar no existe";
            }

            return RedirectToPage("./List");
            
        }
    }
}
