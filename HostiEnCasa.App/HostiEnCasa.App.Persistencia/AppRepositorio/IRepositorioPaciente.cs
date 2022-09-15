using System;
using System.Collections.Generic;
using System.Linq;
using HostiEnCasa.App.Dominio;

namespace HostiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        int AddPaciente(Paciente paciente);
        int UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);    
        Paciente GetPaciente(int idPaciente);
        Medico AsignarMedico(int idPaciente, int idMedico);
        List<Paciente> GetPacienteSignoFrecuencia();
        List<SignoVital> GetSignosPaciente(int idPaciente);
        List<SignoVital> GetSignosPacienteQuery(int idPaciente);
    }

}