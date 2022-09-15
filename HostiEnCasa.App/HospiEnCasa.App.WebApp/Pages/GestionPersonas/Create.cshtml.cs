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
        private IRepositorioPaciente _pacienteRepository = new RepositorioPaciente( new HostiEnCasa.App.Persistencia.AppContext() );
        public List<Persona> listadoPersonas { get; set;}

        public void OnGet()
        {
            var paciente = _pacienteRepository.GetPacienteAll(2);
            if (paciente != null)
                Console.WriteLine(paciente.SignosVitales);

            listadoPersonas = new List<Persona>();
            listadoPersonas = _personaRepository.ObtenerTodo();
        }

        public void OnPost(){
            var noDocumento = Request.Form["noDocumento"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var telefono = Request.Form["telefono"];
            var genero = Request.Form["genero"];
            var discriminador = Request.Form["discriminador"];

            //Validar los datos de la persona, expresiones regulares, condicionales, etc.

            if( discriminador == "Paciente" ){

                var paciente = new Paciente{
                    NoDocumento = noDocumento,
                    Nombre = nombre,
                    Apellidos = apellido,
                    NumeroTelefono = telefono,
                    Genero = (genero == 0 ? Genero.Femenino : Genero.Masculino),
                    Discriminator = discriminador,
                    Direccion = "Calle falsa 123", 
                    Latitud = 123.23F,
                    Longitud = 65.34F,
                    Ciudad = "Pasto",
                    FechaNacimiento = new DateTime(2000, 01, 01),
                    SignosVitales = new List<SignoVital>{
                        new SignoVital { FechaHora = new DateTime(2022, 09, 14), Valor = 80.5F, Signo = TipoSigno.TensionArterial },
                        new SignoVital { FechaHora = new DateTime(2022, 09, 14), Valor = 110F, Signo = TipoSigno.FrecuenciaCardica },
                        new SignoVital { FechaHora = new DateTime(2022, 09, 14), Valor = 70F, Signo = TipoSigno.FrecuenciaRespiratoria },
                        new SignoVital { FechaHora = new DateTime(2022, 09, 14), Valor = 95F, Signo = TipoSigno.SaturacionOxigeno },
                        new SignoVital { FechaHora = new DateTime(2022, 09, 14), Valor = 36F, Signo = TipoSigno.TemperaturaCorporal }
                    }
                };

                var result = _pacienteRepository.AddPaciente(paciente);

                //Mostrar al front el resultado de la operación
                if( result > 0){
                    Console.WriteLine("Se inserto correctamente el paciente");
                }else{
                    Console.WriteLine("No se pudo insertar el paciente");
                }

            }else{
                var persona = new Persona{
                    NoDocumento = noDocumento,
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

        public IActionResult OnPostConsultarPersona(string documento){

            var persona = _personaRepository.BuscarPorNoDocumento(documento);

            return new JsonResult( persona );
        }

    
    }
}
