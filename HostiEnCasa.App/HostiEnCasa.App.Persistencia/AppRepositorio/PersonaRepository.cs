using System;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia{

    public class PersonaRepository : IPersonaRepository{

        private readonly AppContext _appContext;

        public PersonaRepository( AppContext context ){
            _appContext = context;
        }

        int IPersonaRepository.Add(Persona persona){
            _appContext.Personas.Add(persona);
            return _appContext.SaveChanges();
        }

    }
}