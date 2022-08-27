using HostiEnCasa.App.Dominio;
using HostiEnCasa.App.Persistencia;
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
            Console.WriteLine("Registrando una persona");
            //addPersona();
            //addPaciente();

            var persona = new Persona{
                Nombre = "Juan Carlos",
                Apellidos = "Zambrano",
                NumeroTelefono = "3123445566",
                Genero = Genero.Masculino,
                Discriminator = "Persona"
            };

            var result = _personaRepository.Add(persona);

            if( result > 0){
                Console.WriteLine("Se inserto la persona");
            }else{
                Console.WriteLine("No se pudo insertar");
            }

        }        

        public static void addPersona(){
            var persona = new Persona{
                Nombre = "Juan Carlos",
                Apellidos = "Zambrano Montealegre",
                NumeroTelefono = "317123456",
                Genero = Genero.Masculino,
                Discriminator = "Sr"
            };

            _repositorioPersona.AddPersona(persona);
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
                FechaNacimiento = new DateTime(1990, 06, 28)
            };
            _repositorioPaciente.AddPaciente(paciente);
        }

    }
}