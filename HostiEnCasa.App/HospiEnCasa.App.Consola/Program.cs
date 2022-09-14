using HostiEnCasa.App.Dominio;
using HostiEnCasa.App.Persistencia;
using System.Collections.Generic;

using System;

namespace HospiEnCasa.App.Consola
{
    public class Program
    {
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new HostiEnCasa.App.Persistencia.AppContext()); 
        private static IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new HostiEnCasa.App.Persistencia.AppContext()); 

        private static IPersonaRepository _personaRepository = new PersonaRepository( new HostiEnCasa.App.Persistencia.AppContext() );

        public static void Main(string[] args)
        {            
            
            //addPersona();
            addPaciente();
            //agregarSignoPaciente(2);
            //FindAll(); 
            //FindByName();          
            //Update();
            //Delete();    
            //FindAll();        
            //ObtenerTodasPersonas();
            //BuscarPorNombre();
            //Buscador();
            //ActualizarPersona();
            //EliminarPersona();
        }        

        public static void addPersona(){
            
            Console.WriteLine("Registrando una persona");

            var persona = new Persona{
                Nombre = "Juan Carlos",
                Apellidos = "Zambrano Montealegre",
                NumeroTelefono = "317123456",
                Genero = Genero.Masculino,
                Discriminator = "Sr"
            };

            try
            {
                var result = _personaRepository.AdicionarPersona(persona);

                if( result > 0 )
                    Console.WriteLine("Se inserto correctamente");
                else
                    Console.WriteLine("No se pudo insertar");   
                
            }catch (System.Exception e)
            {
                Console.WriteLine("Ocurrio un error: " + e );
                throw;
            }            
        }

        public static void addPaciente(){
            var paciente = new Paciente{
                Nombre = "Marisol",
                Apellidos = "Ramirez",
                NumeroTelefono = "313123456",
                Genero = Genero.Femenino,
                Discriminator = "Sra",
                Direccion = "Calle falsa 123",
                Longitud = 5.075114F,
                Latitud = -75.52990F,
                Ciudad = "Yumbo",
                FechaNacimiento = new DateTime(1990, 06, 28),
                SignosVitales = new List<SignoVital>{
                    new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 80, Signo = TipoSigno.TensionArterial },
                    new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 120, Signo = TipoSigno.FrecuenciaCardica },
                    new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 60, Signo = TipoSigno.FrecuenciaRespiratoria }
                }
            };
            _repositorioPaciente.AddPaciente(paciente);
        }

        public static void agregarSignoPaciente(int id){
            var paciente = _repositorioPaciente.GetPaciente(id);

            if( paciente != null){

                //paciente.Nombre = "Cambio de nombre";

                if(paciente.SignosVitales != null){
                    //Inserta uno mas al listado
                    paciente.SignosVitales.Add(
                        new SignoVital{ FechaHora = new DateTime(2022, 09, 14), Valor = 40, Signo = TipoSigno.TemperaturaCorporal }
                    );
                }else{
                    //Inserta primera vez
                    paciente.SignosVitales = new List<SignoVital>{
                        new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 80, Signo = TipoSigno.TensionArterial },
                        new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 120, Signo = TipoSigno.FrecuenciaCardica },
                        new SignoVital{ FechaHora = new DateTime(2022, 09, 13), Valor = 60, Signo = TipoSigno.FrecuenciaRespiratoria }
                    };
                }

                var result = _repositorioPaciente.UpdatePaciente(paciente);

                if( result > 0 )
                    Console.WriteLine("Se actualizo el paciente con exito, se afectaron " + result + " registros.");
                else
                    Console.WriteLine("No se logro actualizar el paciente");

            }else{
                Console.WriteLine("No existe el paciente a actualizar");
            }
            
        }

        public static void FindAll(){
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Listado de personas");
            Console.WriteLine("-----------------------------------------------");
            
            var resultGeneral = _personaRepository.GetAll();

            foreach (var resultPersona in resultGeneral)
            {
                Console.WriteLine("Id: " + resultPersona.Id +", Nombres: " + resultPersona.Nombre + ", Apellido: " + resultPersona.Apellidos);
            }
        }

        public static void FindByName(){

            var result = _personaRepository.FindByName("Carlos");

            foreach (var persona in result)
            {
                Console.WriteLine("Id: " + persona.Id +", Nombres: " + persona.Nombre + ", Apellido: " + persona.Apellidos);
            }
        }

        public static void Find(){

            var result = _personaRepository.Buscar(2);
            Console.WriteLine( result.Nombre + ' ' + result.Apellidos );
        }

        public static void Update(){

            var result = _personaRepository.Buscar(1);

            if( result != null){

                result.Apellidos = "Montealegre";
                result.NumeroTelefono = "3009876543";

                var res = _personaRepository.Update(result);

                if(res > 0){
                    Console.WriteLine("Se actualizo con exito");
                }else{
                    Console.WriteLine("No fue posible actualizar");
                }
            }else{
                Console.WriteLine("No existe persona a actualizar");
            }

        }

        public static void Delete(){

            var result = _personaRepository.Buscar(1);

            if( result != null){

                var res = _personaRepository.Delete(result);

                if(res > 0){
                    Console.WriteLine("Se elimino con exito");
                }else{
                    Console.WriteLine("No fue posible eliminar");
                }
            }else{
                Console.WriteLine("No existe persona a eliminar");
            }

        }

        public static void ObtenerTodasPersonas(){

            var listadoPersonas = _personaRepository.ObtenerTodasPersonas();

            foreach (var persona in listadoPersonas)
            {
                Console.WriteLine("Id: " + persona.Id + ", Nombre: " + persona.Nombre + ", Apellido: " + persona.Apellidos + ", Número teléfono: " + persona.NumeroTelefono);
            }

        }

        public static void BuscarPorNombre(){
             
             var listadoPersonas = _personaRepository.ObtenerPersonaPorNombre( "Ped" );

             foreach (var persona in listadoPersonas)
             {
                Console.WriteLine("Id: " + persona.Id + ", Nombre: " + persona.Nombre + ", Apellido: " + persona.Apellidos + ", Número teléfono: " + persona.NumeroTelefono);
             }

        }

        public static void Buscador(){
             
             var listadoPersonas = _personaRepository.Buscador( "12" );

             foreach (var persona in listadoPersonas)
             {
                Console.WriteLine("Id: " + persona.Id + ", Nombre: " + persona.Nombre + ", Apellido: " + persona.Apellidos + ", Número teléfono: " + persona.NumeroTelefono);
             }

        }

        public static void ActualizarPersona(){

            var persona = _personaRepository.Buscar(3);

            if( persona != null){

                persona.NumeroTelefono = "30099887766";
                persona.Apellidos = "Zambrano";
                persona.Nombre = "Juan Carlos";

                var result = _personaRepository.ActualizarPersona(persona);

                if( result > 0 )
                    Console.WriteLine("Se actualizo con exito, se afectaron " + result + " registros.");
                else
                    Console.WriteLine("No se logro actualizar");

            }else{
                Console.WriteLine("No existe la persona a actualizar");
            }
        }

        public static void EliminarPersona(){

            var persona = _personaRepository.Buscar(3);

            if( persona != null){

                var result = _personaRepository.EliminarPersona(persona);

                if( result > 0 )
                    Console.WriteLine("Se elimino con exito, se afectaron " + result + " registros.");
                else
                    Console.WriteLine("No se logro eliminar");

            }else{
                Console.WriteLine("No existe la persona a eliminar");
            }
        }
       
    }
}