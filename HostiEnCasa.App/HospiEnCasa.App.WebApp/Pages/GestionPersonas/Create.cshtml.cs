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
    public class CreateModel : PageModel
    {

        private IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );

        public void OnGet()
        {
        }

        public void OnPost(){
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var telefono = Request.Form["telefono"];
            var genero = Request.Form["genero"];
            var discriminador = Request.Form["discriminador"];

            //Validar los datos de la persona, expresiones regulares, condicionales, etc.

            var persona = new Persona{
                Nombre = nombre,
                Apellidos = apellido,
                NumeroTelefono = telefono,
                Genero = (genero == 0 ? Genero.Femenino : Genero.Masculino),
                Discriminator = discriminador
            };

            var result = _personaRepository.AdicionarPersona(persona);

            //Mostrar al front el resultado de la operación
            if( result > 0){
                Console.WriteLine("Se inserto correctamente");
            }else{
                Console.WriteLine("No se pudo insertar");
            }
            
        }
    }
}
