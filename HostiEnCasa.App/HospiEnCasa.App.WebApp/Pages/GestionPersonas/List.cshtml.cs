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
    public class ListModel : PageModel
    {
        private IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );
        public List<Persona> listadoPersonas { get; set;}
        public string mensaje;

        public void OnGet()
        {
            listadoPersonas = new List<Persona>();
            listadoPersonas = _personaRepository.ObtenerTodo();
            if(ViewData["mensaje"] != null)
                mensaje = ViewData["mensaje"].ToString();
            else
                mensaje = "";
        }

        public IActionResult OnPostUpdate()
        {
            return Content("Se ejecuto el consumo del metodo Update via ajax");
        }

        public IActionResult OnPostUpdateJson([FromBody]Persona persona)
        {
            var personaResult = _personaRepository.Buscar( persona.Id );
            var mensaje = "";

            if( personaResult != null){

                personaResult.Nombre = persona.Nombre;
                personaResult.Apellidos = persona.Apellidos;
                personaResult.NumeroTelefono = persona.NumeroTelefono;
                personaResult.Genero = (persona.Genero == 0 ? Genero.Femenino : Genero.Masculino);
            
                var result = _personaRepository.Update(personaResult);

                if( result > 0){
                    mensaje = "Se actualizo correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "La persona a actualizar no existe";
            }

            //return new JsonResult(persona);

            return Content(mensaje);

        } 
    }
}
