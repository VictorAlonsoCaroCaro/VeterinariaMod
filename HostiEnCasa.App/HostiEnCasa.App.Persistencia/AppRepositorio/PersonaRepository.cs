using System;
using HostiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace HostiEnCasa.App.Persistencia{

    public class PersonaRepository : IPersonaRepository{

        private readonly AppContext _appContext;

        public PersonaRepository( AppContext context ){
            _appContext = context;
        }

        int IPersonaRepository.AdicionarPersona(Persona persona){
            _appContext.Personas.Add(persona);
            return _appContext.SaveChanges();
        }

        bool IPersonaRepository.Add(Persona persona){
            _appContext.Personas.Add(persona);
            return (_appContext.SaveChanges() > 0 ? true : false);            
        }

        Persona IPersonaRepository.Buscar(int id){
            return _appContext.Personas.Find(id);
        }

        IEnumerable<Persona> IPersonaRepository.GetAll(){
            return _appContext.Personas;
        }

        List<Persona> IPersonaRepository.ObtenerTodo(){
            return _appContext.Personas.ToList();
        }

        IEnumerable<Persona> IPersonaRepository.FindByName(string name){
            return _appContext.Personas.Where(p => p.Nombre.Contains(name) );
        }

        IEnumerable<Persona> IPersonaRepository.FindMultipleParameter(string value){
            return _appContext.Personas.Where(p => p.Nombre.Contains(value) || p.Apellidos.Contains(value) || p.NumeroTelefono.Contains(value));
        }

        int IPersonaRepository.Update(Persona persona){
            _appContext.Personas.Update(persona);
            return _appContext.SaveChanges();
        }

        int IPersonaRepository.Delete(Persona persona){
            _appContext.Personas.Remove(persona);
            return _appContext.SaveChanges();
        }

        IEnumerable<Persona> IPersonaRepository.ObtenerTodasPersonas(){
            return _appContext.Personas;
        }

        List<Persona> IPersonaRepository.ObtenerPersonaPorNombre(string nombre){
            return _appContext.Personas.Where( p => p.Nombre.Contains(nombre) ).ToList();
        }

        IEnumerable<Persona> IPersonaRepository.Buscador(string busqueda){
            return _appContext.Personas.Where( p => p.Nombre.Contains(busqueda) || p.Apellidos.Contains(busqueda) || p.NumeroTelefono.Contains(busqueda));
        }

        int IPersonaRepository.ActualizarPersona(Persona persona){
            _appContext.Personas.Update(persona);
            return _appContext.SaveChanges();
        }

        int IPersonaRepository.EliminarPersona(Persona persona){
            _appContext.Personas.Remove(persona);
            return _appContext.SaveChanges();
        }

    }
}