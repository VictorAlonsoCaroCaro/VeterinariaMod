using System;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia{

    public interface IPersonaRepository{
        int AdicionarPersona(Persona persona);
        bool Add(Persona persona);
        Persona Buscar(int id);
    }

}