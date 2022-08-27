using System;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia{

    public interface IPersonaRepository{

        int Add(Persona persona);

    }

}