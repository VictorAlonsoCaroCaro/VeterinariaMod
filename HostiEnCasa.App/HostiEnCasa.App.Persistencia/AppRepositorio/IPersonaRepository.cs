using System;
using HostiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace HostiEnCasa.App.Persistencia{

    public interface IPersonaRepository{
        int AdicionarPersona(Persona persona);
        bool Add(Persona persona);
        Persona Buscar(int id);
        IEnumerable<Persona> GetAll();
        List<Persona> ObtenerTodo();
        IEnumerable<Persona> FindByName(string name);
        IEnumerable<Persona> FindMultipleParameter(string value);
        int Update(Persona persona);
        int Delete(Persona persona);

        IEnumerable<Persona> ObtenerTodasPersonas();
        List<Persona> ObtenerPersonaPorNombre(string nombre);
        IEnumerable<Persona> Buscador(string busqueda);
        int ActualizarPersona(Persona persona);
        int EliminarPersona(Persona persona);
        Persona BuscarPorNoDocumento(string NoDocumento);
    }

}